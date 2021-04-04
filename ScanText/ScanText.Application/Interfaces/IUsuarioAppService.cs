using ScanText.Application.ViewModels;
using ScanText.Domain.UsuarioDTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface IUsuarioAppService : IServiceApp<UsuarioViewModel>
    {
        Usuario UsuarioViewModelToUsuario(UsuarioViewModel usuarioViewModel);
        Task<bool> IndicaUsuarioExistenteAsync(string username);
        Task<string> ObterEmailUsuarioLogado();
        Task<UsuarioViewModel> CarregarDadosCadastroUsuario();
    }
}
