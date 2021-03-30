using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Security.Authentication.Entities;
using ScanText.Security.Authentication.Interfaces;
using ScanText.Security.Encrypt.Interfaces;
using System;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IEncryptData _encryptData;
        private readonly ITokenService _token;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public LoginAppService(ITokenService token, IEncryptData encryptData, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _token = token;
            _encryptData = encryptData;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<LoginViewModel> LoginAsync(LoginViewModel userLogin)
        {
            ValidarDadosLogin(userLogin);
            var passwordEncripty = _encryptData.Encrypt(userLogin.Password);
            var login = await _usuarioRepository.Login(userLogin.Username, passwordEncripty);

            if (login == null)
                throw new Exception("Usuário ou senha incorreto.");

            var usuarioAuthentication = _mapper.Map<UsuarioAuthentication>(login);
            var token = _token.GenerateToken(usuarioAuthentication);
            login.Token = token;
            return _mapper.Map<LoginViewModel>(login);
        }

        public void ValidarDadosLogin(LoginViewModel login)
        {
            if (string.IsNullOrEmpty(login.Username))
                throw new Exception("Usuário não informado.");

            if (string.IsNullOrEmpty(login.Password))
                throw new Exception("Senha não informada.");
        }
    }
}
