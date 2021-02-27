using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.UsuarioDTO.Entities;
using ScanText.Security.Authentication.Entities;
using ScanText.Security.Authentication.Interfaces;
using ScanText.Security.Encrypt.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEncryptData _encryptData;
        private readonly IMapper _mapper;
        private readonly IToken _token;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IEncryptData encryptData, IMapper mapper, IToken token)
        {
            _usuarioRepository = usuarioRepository;
            _encryptData = encryptData;
            _mapper = mapper;
            _token = token;
        }

        public Task AtualizarAsync(UsuarioViewModel usuarioViewModel, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IndicaUsuarioExistenteAsync(string username)
        {
            return await _usuarioRepository.IndicaUsuarioExistenteAsync(username);
        }

        public async Task InserirAsync(UsuarioViewModel usuarioViewModel)
        {
            var indicaUsuarioCadastrado = await IndicaUsuarioExistenteAsync(usuarioViewModel.Username);
            
            if (!indicaUsuarioCadastrado)
            {
                var passwordEncripty = _encryptData.Encrypt(usuarioViewModel.Password);
                usuarioViewModel.Password = passwordEncripty;
                var usuario = UsuarioViewModelToUsuario(usuarioViewModel);
                await _usuarioRepository.InserirAsync(usuario);
            } 
            else
            {
                throw new Exception("Usuário já cadastrado.");
            }
        }

        public Task<UsuarioViewModel> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioViewModel>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario UsuarioViewModelToUsuario(UsuarioViewModel usuarioViewModel)
        {
            return _mapper.Map<Usuario>(usuarioViewModel);
        }

        public async Task<LoginViewModel> LoginAsync(LoginViewModel userLogin)
        {
            ValidarUsuarioSenhaPreenchido(userLogin);
            var passwordEncripty = _encryptData.Encrypt(userLogin.Password);
            var login = await _usuarioRepository.Login(userLogin.Username, passwordEncripty);

            if (login == null)
                throw new Exception("Usuário ou senha incorreto.");

            var usuarioAuthentication = _mapper.Map<UsuarioAuthentication>(login);
            var token = _token.GenerateToken(usuarioAuthentication);
            login.Token = token;
            return _mapper.Map<LoginViewModel>(login);
        }

        public void ValidarUsuarioSenhaPreenchido(LoginViewModel login)
        {
            if (string.IsNullOrEmpty(login.Username))
                throw new Exception("Usuário não informado.");

            if (string.IsNullOrEmpty(login.Password))
                throw new Exception("Senha não informada.");
        }
    }
}
