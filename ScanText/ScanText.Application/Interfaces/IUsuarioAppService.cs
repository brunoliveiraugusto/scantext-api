using ScanText.Application.ViewModels;
using ScanText.Domain.UsuarioDTO.Entities;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface IUsuarioAppService : IServiceApp<UsuarioViewModel>
    {
        Usuario UsuarioViewModelToUsuario(UsuarioViewModel usuarioViewModel);
        Task<bool> IndicaUsuarioExistente(string username);
        Task<string> ObterEmailUsuarioLogado();
        Task<UsuarioViewModel> CarregarDadosCadastroUsuario();
        Task<bool> AtualizarDadosCadastroUsuario(UsuarioViewModel usuario);
    }
}
