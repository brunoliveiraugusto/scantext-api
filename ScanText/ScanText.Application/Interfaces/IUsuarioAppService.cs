﻿using ScanText.Application.ViewModels;
using ScanText.Domain.UsuarioDTO.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface IUsuarioAppService : IServiceApp<UsuarioViewModel>
    {
        Usuario UsuarioViewModelToUsuario(UsuarioViewModel usuarioViewModel);
        Task<bool> IndicaUsuarioExistente(Expression<Func<Usuario, bool>> expression);
        Task<string> ObterEmailUsuarioLogado();
        Task<UsuarioViewModel> CarregarDadosCadastroUsuario();
        Task<bool> AtualizarDadosCadastroUsuario(UsuarioViewModel usuarioViewModel);
    }
}
