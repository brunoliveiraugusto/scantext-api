using ScanText.Domain.UsuarioDTO.Entities;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<bool> IndicaUsuarioExistenteAsync(string username);
        Task<Login> Login(string username, string password);
    }
}
