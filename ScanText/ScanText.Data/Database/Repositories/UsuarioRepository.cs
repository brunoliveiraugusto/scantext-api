using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.UsuarioDTO.Entities;
using ScanText.Infra.Configuration.Database.Context;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ScanTextMongoContext context) : base(context)
        {

        }

        public async Task<bool> IndicaUsuarioExistenteAsync(string username)
        {
            return await DbSet.AsQueryable().AnyAsync(usuario => usuario.Username.ToLower() == username.ToLower());
        }

        public async Task<Login> Login(string username, string password)
        {
            return await DbSet.AsQueryable().Where(usuario => usuario.Username.ToLower() == username.ToLower() && usuario.Password == password)
                                            .Select(usuario => new Login()
                                            {
                                                Id = usuario.Id,
                                                Username = usuario.Username,
                                                Role = usuario.Role
                                            })
                                            .FirstOrDefaultAsync();
        }
    }
}
