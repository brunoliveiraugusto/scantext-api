using ScanText.Domain.Usuario.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<bool> IndicaUsuarioExistente(Expression<Func<Usuario, bool>> expression);
        Task<Login> Login(string username, string password);
        Task<string> ObterEmailUsuarioLogado(Guid idUsuario);
        Task<string> ObterNomeUsuarioLogado(Guid idUsuario);
        Task<Usuario> CarregarDadosCadastro(Guid idUsuario);
        Task<bool> AtualizarDadosCadastro(Usuario usuario, Guid idUsuario);
        Task<string> ObterEmailUsuarioPorUsername(string username);
        Task<Usuario> ObterNomeEmailUsuarioPorUsername(string username);
        Task<Usuario> ObterUsuarioPorUsername(string username);
    }
}
