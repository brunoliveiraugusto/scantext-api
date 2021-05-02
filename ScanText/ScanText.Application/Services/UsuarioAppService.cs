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

namespace ScanText.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEncryptData _encryptData;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _user;
        private readonly INotificationService _notificationService;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IEncryptData encryptData, IMapper mapper, IUsuarioService user, INotificationService notificationService)
        {
            _usuarioRepository = usuarioRepository;
            _encryptData = encryptData;
            _mapper = mapper;
            _user = user;
            _notificationService = notificationService;
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
    }
}
