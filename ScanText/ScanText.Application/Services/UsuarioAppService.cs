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

namespace ScanText.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEncryptData _encryptData;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _user;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IEncryptData encryptData, IMapper mapper, IUsuarioService user)
        {
            _usuarioRepository = usuarioRepository;
            _encryptData = encryptData;
            _mapper = mapper;
            _user = user;
        }

        public Task AtualizarAsync(UsuarioViewModel usuarioViewModel, Guid id)
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

            return await _usuarioRepository.IndicaUsuarioExistenteAsync(expression);
        }

        public async Task<bool> InserirAsync(UsuarioViewModel usuarioViewModel)
        {
            var indicaUsuarioCadastrado = await IndicaUsuarioExistente(usuarioViewModel.Username);
            
            if (!indicaUsuarioCadastrado)
            {
                var passwordEncripty = _encryptData.Encrypt(usuarioViewModel.Password);
                usuarioViewModel.Password = passwordEncripty;
                var usuario = UsuarioViewModelToUsuario(usuarioViewModel);
                await _usuarioRepository.InserirAsync(usuario);
            } 
            else
            {
                throw new UserAlreadyExistsException();
            }

            return true;
        }

        public async Task<string> ObterEmailUsuarioLogado()
        {
            var idUsuario = _user.GetUserId();
            return await _usuarioRepository.ObterEmailUsuarioLogado(idUsuario);
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
    }
}
