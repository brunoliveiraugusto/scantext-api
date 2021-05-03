using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Usuario.Entities;
using ScanText.Infra.Configuration.Database.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ScanTextMongoContext context) : base(context)
        {

        }

        public async Task<bool> IndicaUsuarioExistente(Expression<Func<Usuario, bool>> expression)
        {
            return await DbSet.AsQueryable().AnyAsync(expression);
        }

        public async Task<Login> Login(string username, string password)
        {
            return await DbSet.AsQueryable().Where(usuario => usuario.Username.ToLower() == username.ToLower() && usuario.Password == password)
                                            .Select(usuario => new Login()
                                            {
                                                Id = usuario.Id,
                                                Username = usuario.Username,
                                                Role = usuario.Role,
                                                NomeCompleto = usuario.NomeCompleto
                                            })
                                            .FirstOrDefaultAsync();
        }

        public async Task<string> ObterEmailUsuarioLogado(Guid idUsuario)
        {
            return await DbSet.AsQueryable().Where(usuario => usuario.Id == idUsuario).Select(usuario => usuario.Email).FirstOrDefaultAsync();
        }

        public async Task<string> ObterNomeUsuarioLogado(Guid idUsuario)
        {
            return await DbSet.AsQueryable().Where(usuario => usuario.Id == idUsuario).Select(usuario => usuario.NomeCompleto).FirstOrDefaultAsync();
        }

        public async Task<Usuario> CarregarDadosCadastro(Guid idUsuario)
        {
            return await DbSet.AsQueryable().Where(usuario => usuario.Id == idUsuario)
                    .Select(usuario => new Usuario
                    {
                        Id = usuario.Id,
                        Username = usuario.Username,
                        DataNascimento = usuario.DataNascimento,
                        Email = usuario.Email,
                        NomeCompleto = usuario.NomeCompleto
                    })
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> AtualizarDadosCadastro(Usuario usuario, Guid idUsuario)
        {
            try
            {
                var user = await ObterPorIdAsync(idUsuario);

                user.Username = usuario.Username;
                user.NomeCompleto = usuario.NomeCompleto;
                user.DataNascimento = usuario.DataNascimento;
                user.Email = usuario.Email;

                await DbSet.ReplaceOneAsync(Builders<Usuario>.Filter.Eq("_id", idUsuario), user);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<string> ObterEmailUsuarioPorUsername(string username)
        {
            return await DbSet.AsQueryable().Where(usuario => usuario.Username == username).Select(usuario => usuario.Email).FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterNomeEmailUsuarioPorUsername(string username)
        {
            return await DbSet.AsQueryable().Where(usuario => usuario.Username == username)
                .Select(usuario => new Usuario
                {
                    NomeCompleto = usuario.NomeCompleto,
                    Email = usuario.Email
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterUsuarioPorUsername(string username)
        {
            return await DbSet.AsQueryable().Where(usuario => usuario.Username == username).FirstOrDefaultAsync();
        }
    }
}
