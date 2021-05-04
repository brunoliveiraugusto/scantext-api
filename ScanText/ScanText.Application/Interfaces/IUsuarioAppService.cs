using ScanText.Application.ViewModels;
using ScanText.Domain.Usuario.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface IUsuarioAppService : IServiceApp<UsuarioViewModel>
    {
        Task<bool> IndicaUsuarioExistente(string username, Guid? idUsuario = null);
        Task<string> ObterEmailUsuarioLogado();
        Task<UsuarioViewModel> CarregarDadosCadastroUsuario();
        Task<bool> AtualizarDadosCadastroUsuario(UsuarioViewModel usuarioViewModel, Guid idUsuario);
        Task<IEnumerable<string>> ObterContatosUsuarioParaRedefinirSenha(string username);
        Task<bool> EnviarEmailRedefinicaoSenha(string username);
        Task<bool> AtualizarSenha(AtualizaSenhaViewModel atualizaSenha);
    }
}
