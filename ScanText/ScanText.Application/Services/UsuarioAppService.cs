using AutoMapper;
using ScanText.Application.Utils.Exceptions;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Usuario.Entities;
using ScanText.Security.Authentication.Interfaces;
using ScanText.Security.Encrypt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ScanText.Domain.Utils.Interfaces;
using ScanText.Domain.Usuario.Helper;
using ScanText.Domain.Email.Resources;
using System.Web;
using ScanText.Domain.Email.Entities.Interfaces;
using Microsoft.Extensions.Options;
using ScanText.Infra.CrossCutting.Settings;

namespace ScanText.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEncryptData _encryptData;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _user;
        private readonly INotificationService _notificationService;
        private readonly ITokenService _tokenService;
        private readonly IEmailAddress _emailAddress;
        private readonly IEmailRepository _emailRepository;
        private readonly ScanTextClientSettings _clientSettings;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IEncryptData encryptData, IMapper mapper, 
            IUsuarioService user, INotificationService notificationService, ITokenService tokenService, IEmailAddress emailAddress,
            IEmailRepository emailRepository, IOptions<ScanTextClientSettings> optionsClientSettings)
        {
            _usuarioRepository = usuarioRepository;
            _encryptData = encryptData;
            _mapper = mapper;
            _user = user;
            _notificationService = notificationService;
            _tokenService = tokenService;
            _emailAddress = emailAddress;
            _emailRepository = emailRepository;
            _clientSettings = optionsClientSettings.Value;
        }

        public Task<UsuarioViewModel> Atualizar(UsuarioViewModel usuarioViewModel, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IndicaUsuarioExistente(string username, Guid? idUsuario = null)
        {
            Expression<Func<Usuario, bool>> expression = null;

            if(idUsuario != null)
                expression = usuario => usuario.Username == username && usuario.Id != idUsuario;
            else
                expression = usuario => usuario.Username == username;

            return await _usuarioRepository.IndicaUsuarioExistente(expression);
        }

        public async Task<UsuarioViewModel> Inserir(UsuarioViewModel usuarioViewModel)
        {
            var indicaUsuarioCadastrado = await IndicaUsuarioExistente(usuarioViewModel.Username);
            
            if (!indicaUsuarioCadastrado)
            {
                var passwordEncripty = _encryptData.Encrypt(usuarioViewModel.Password);
                usuarioViewModel.Password = passwordEncripty;
                var usuario = ConvertModelMapper<Usuario, UsuarioViewModel>(usuarioViewModel);
                if (!_notificationService.ValidEntity(usuario))
                    return null;

                await _usuarioRepository.InserirAsync(usuario);
                usuario.Password = null;
                return ConvertModelMapper<UsuarioViewModel, Usuario>(usuario);
            } 
            else
            {
                throw new UserAlreadyExistsException();
            }
        }

        public async Task<string> ObterEmailUsuarioLogado()
        {
            var idUsuario = _user.GetUserId();
            return await _usuarioRepository.ObterEmailUsuarioLogado(idUsuario);
        }

        public Task<UsuarioViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioViewModel> CarregarDadosCadastroUsuario()
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.CarregarDadosCadastro(_user.GetUserId()));
        }

        public async Task<bool> AtualizarDadosCadastroUsuario(UsuarioViewModel usuarioViewModel, Guid idUsuario)
        {
            var indicaUsuarioExistente = await IndicaUsuarioExistente(usuarioViewModel.Username, idUsuario);

            if (!indicaUsuarioExistente)
                return await _usuarioRepository.AtualizarDadosCadastro(_mapper.Map<Usuario>(usuarioViewModel), idUsuario);
            else
                throw new UserAlreadyExistsException();
        }

        public T ConvertModelMapper<T, M>(M model)
            where T : class
            where M : class
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> ObterContatosUsuarioParaRedefinirSenha(string username)
        {
            string email = await _usuarioRepository.ObterEmailUsuarioPorUsername(username);

            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            string emailMascara = UsuarioHelper.AplicarMascaraEmail(email);
            return new List<string> { emailMascara };
        }

        public async Task<bool> EnviarEmailRedefinicaoSenha(string username)
        {
            try
            {
                var usuario = await _usuarioRepository.ObterNomeEmailUsuarioPorUsername(username);
                string token = _tokenService.GenerateSimpleToken();
                string url = $"{_clientSettings.Url}/atualizar-senha/{HttpUtility.UrlEncode(token)}";
                var emailHtml = Email.TemplateEmailRedefinicaoSenha
                                .Replace("{usuario}", usuario.NomeCompleto)
                                .Replace("{url}", url);

                var email = _emailAddress.GetEmailAddress(usuario.NomeCompleto, usuario.Email, "ScanText - Redefinição de Senha", string.Empty, emailHtml);
                return await _emailRepository.EnviarEmailAsync(email);
            }
            catch(Exception)
            {
                _notificationService.AddNotification("Envio do E-mail de Redefinição de Senha", "Falha ao enviar o e-mail para a redefinição de senha, tente novamente.");
                return false;
            }
        }

        public async Task<bool> AtualizarSenha(AtualizaSenhaViewModel atualizaSenha)
        {
            if(string.IsNullOrEmpty(atualizaSenha.Token) || !_tokenService.ValidateSimpleToken(atualizaSenha.Token))
            {
                _notificationService.AddNotification("Token Inválido", "O token informado é inválido, acesse o link enviado por e-mail e tente novamente.");
                return false;
            }

            var usuario = await _usuarioRepository.ObterUsuarioPorUsername(atualizaSenha.Username);
            string password = _encryptData.Encrypt(atualizaSenha.Senha);
            usuario.Password = password;
            await _usuarioRepository.AtualizarAsync(usuario, usuario.Id);
            return true;
        }
    }
}
