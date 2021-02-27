using ScanText.Application.ViewModels;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface ILoginAppService
    {
        Task<LoginViewModel> LoginAsync(LoginViewModel userLogin);
        void ValidarDadosLogin(LoginViewModel login);
    }
}
