using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class ImagemAppService : IImagemAppService
    {
        private readonly IImagemRepository _imagemRepository;
        private readonly IMapper _mapper;

        public ImagemAppService(IImagemRepository imagemRepository, IMapper mapper)
        {
            _imagemRepository = imagemRepository;
            _mapper = mapper;
        }

        public async Task AtualizarAsync(ImagemViewModel imagemViewModel)
        {
            var imagem = ImagemViewModelToImagem(imagemViewModel);
            await _imagemRepository.AtualizarAsync(imagem);
        }

        public async Task InserirAsync(ImagemViewModel imagemViewModel)
        {
            var imagem = ImagemViewModelToImagem(imagemViewModel);
            await _imagemRepository.InserirAsync(imagem);
        }

        public async Task<ImagemViewModel> ObterPorIdAsync(Guid id)
        {
            var imagem = await _imagemRepository.ObterPorIdAsync(id);
            return _mapper.Map<ImagemViewModel>(imagem);
        }

        public async Task<IEnumerable<ImagemViewModel>> ObterTodosAsync()
        {
            var imagens = await _imagemRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<ImagemViewModel>>(imagens);
        }

        public async Task RemoverAsync(Guid id)
        {
            await _imagemRepository.RemoverAsync(id);
        }

        public Imagem ImagemViewModelToImagem(ImagemViewModel imagemViewModel)
        {
            return _mapper.Map<Imagem>(imagemViewModel);
        }
    }
}
