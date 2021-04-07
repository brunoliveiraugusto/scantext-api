using ScanText.Application.ViewModels;
using ScanText.Domain.Usuario.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface IUsuarioAppService : IServiceApp<UsuarioViewModel>
    {
        Usuario UsuarioViewModelToUsuario(UsuarioViewModel usuarioViewModel);
        Task<bool> IndicaUsuarioExistente(string username, Guid? idUsuario = null);
        Task<string> ObterEmailUsuarioLogado();
        Task<UsuarioViewModel> CarregarDadosCadastroUsuario();
        Task<bool> AtualizarDadosCadastroUsuario(UsuarioViewModel usuarioViewModel, Guid idUsuario);
    }
}
