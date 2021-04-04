using ScanText.Domain.UsuarioDTO.Entities;
using System;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<bool> IndicaUsuarioExistenteAsync(string username);
        Task<Login> Login(string username, string password);
        Task<string> ObterEmailUsuarioLogado(Guid idUsuario);
        Task<string> ObterNomeUsuarioLogado(Guid idUsuario);
        Task<Usuario> CarregarDadosCadastro(Guid idUsuario);
    }
}
