using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Data.Utils;
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

        public async Task AtualizarAsync(ImagemViewModel imagemViewModel, Guid id)
        {
            var imagem = ImagemViewModelToImagem(imagemViewModel);
            imagem.DataAtualizacao = DateTime.Now;
            await _imagemRepository.AtualizarAsync(imagem, id);
        }

        public async Task<bool> InserirAsync(ImagemViewModel imagemViewModel)
        {
            var imagem = ImagemViewModelToImagem(imagemViewModel);
            imagem.DataCadastro = DateTime.Now;
            await _imagemRepository.InserirAsync(imagem);
            return true;
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

        public PaginationFilterViewModel<ImagemViewModel> ObterImagensPaginadas(PaginationFilterViewModel<ImagemViewModel> paginationFilterViewModel)
        {
            var pagination = _mapper.Map<PaginationFilter<Imagem>>(paginationFilterViewModel);
            var resultPagination = _imagemRepository.ObterImagensPaginadas(pagination);
            return _mapper.Map<PaginationFilterViewModel<ImagemViewModel>>(resultPagination);
        }
    }
}
