using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Data.Utils;
using ScanText.Domain.Email.Entities.Interfaces;
using ScanText.Domain.Imagem.Entities;
using ScanText.Domain.Utils.Interfaces;
using ScanText.Security.Authentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class ImagemAppService : IImagemAppService
    {
        private readonly IImagemRepository _imagemRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _user;
        private readonly IEmailRepository _emailRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailAddress _emailAddress;
        private readonly INotificationService _notificationService;
        protected Guid IdUsuario { get; private set; }

        public ImagemAppService(IImagemRepository imagemRepository, IMapper mapper, 
            IUsuarioService user, IEmailRepository emailRepository, IUsuarioRepository usuarioRepository,
            IEmailAddress emailAddress, INotificationService notificationService)
        {
            _imagemRepository = imagemRepository;
            _mapper = mapper;
            _user = user;
            _emailRepository = emailRepository;
            _usuarioRepository = usuarioRepository;
            _emailAddress = emailAddress;
            _notificationService = notificationService;
            IdUsuario = _user.GetUserId();
        }

        public async Task<ImagemViewModel> Atualizar(ImagemViewModel imagemViewModel, Guid id)
        {
            var imagem = ConvertModelMapper<Imagem, ImagemViewModel>(imagemViewModel);
            imagem.DataAtualizacao = DateTime.Now;
            
            if (!_notificationService.ValidEntity(imagem))
                return null;

            await _imagemRepository.AtualizarAsync(imagem, id);
            return ConvertModelMapper<ImagemViewModel, Imagem>(imagem);
        }

        public async Task<ImagemViewModel> Inserir(ImagemViewModel imagemViewModel)
        {
            var imagem = ConvertModelMapper<Imagem, ImagemViewModel>(imagemViewModel);
            imagem.DataCadastro = DateTime.Now;
            imagem.IdUsuario = IdUsuario;
            if (!_notificationService.ValidEntity(imagem))
                return null;

            await _imagemRepository.InserirAsync(imagem);
            return ConvertModelMapper<ImagemViewModel, Imagem>(imagem);
        }

        public async Task<ImagemViewModel> ObterPorId(Guid id)
        {
            var imagem = await _imagemRepository.ObterPorIdAsync(id);
            return _mapper.Map<ImagemViewModel>(imagem);
        }

        public async Task<IEnumerable<ImagemViewModel>> ObterTodos()
        {
            var imagens = await _imagemRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<ImagemViewModel>>(imagens);
        }

        public async Task Remover(Guid id)
        {
            await _imagemRepository.RemoverAsync(id);
        }

        private T ConvertModelMapper<T, M>(M model) where T : class
        {
            return _mapper.Map<T>(model);
        }

        public PaginationFilterViewModel<ImagemViewModel> ObterImagensPaginadasPorUsuario(PaginationFilterViewModel<ImagemViewModel> paginationFilterViewModel)
        {
            var pagination = _mapper.Map<PaginationFilter<Imagem>>(paginationFilterViewModel);
            var resultPagination = _imagemRepository.ObterImagensPaginadasPorIdUsuario(pagination, IdUsuario);
            return _mapper.Map<PaginationFilterViewModel<ImagemViewModel>>(resultPagination);
        }

        public async Task EnviarEmailImagemProcessada(Guid idImagem)
        {
            var nomeUsuarioTask = _usuarioRepository.ObterNomeUsuarioLogado(IdUsuario);
            var emailUsuarioTask = _usuarioRepository.ObterEmailUsuarioLogado(IdUsuario);
            var imagemTask = _imagemRepository.ObterPorIdAsync(idImagem);

            var imagem = await imagemTask;
            var emailUsuario = await emailUsuarioTask;
            var nomeUsuario = await nomeUsuarioTask;
            
            var email = MontarEstruturaEmail(imagem);
            var emailSend = _emailAddress.GetEmailAddress(nomeUsuario, emailUsuario, email.subject, string.Empty, email.htmlContent);

            await _emailRepository.EnviarEmailAsync(emailSend);
        }

        private (string htmlContent, string subject) MontarEstruturaEmail(Imagem imagem)
        {
            return ($"<p><b>Nome:</b> {imagem.Nome}</p>" +
                    $"<p><b>Assertividade Leitura:</b> {imagem.MeanConfidence * 100}%</p>" +
                    $"<p><b>Formato:</b> {imagem.Formato}</p>" +
                    $"<p><b>Texto:</b> {imagem.Texto}</p>" +
                    $"<p><b>Idioma:</b> {imagem.Linguagem.Idioma}</p>" +
                    $"<p><b>Data Digitalização:</b> {imagem.DataAtualizacao?.ToString("dd/MM/yyyy HH:mm:ss") ?? imagem.DataCadastro.ToString("dd/MM/yyyy HH:mm:ss")}</p>", 
                    "Imagem Digitalizada: " + imagem.Nome);
        }
    }
}
