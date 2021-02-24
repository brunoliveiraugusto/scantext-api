using ScanText.Application.ViewModels;
using ScanText.Domain.UsuarioDTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Application.Interfaces
{
    public interface IUsuarioAppService : IServiceApp<UsuarioViewModel>
    {
        Usuario UsuarioViewModelToUsuario(UsuarioViewModel usuarioViewModel);
    }
}
