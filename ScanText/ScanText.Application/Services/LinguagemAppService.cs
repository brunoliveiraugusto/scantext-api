using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ScanText.Application.Services
{
    public class LinguagemAppService : ILinguagemAppService
    {
        private readonly ILinguagemRepository _linguagemRepository;
        private readonly IArquivoIdiomaRepository _arquivoIdiomaRepository;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public LinguagemAppService(ILinguagemRepository linguagemRepository, IMapper mapper, INotificationService notificationService,
            IArquivoIdiomaRepository arquivoIdiomaRepository)
        {
            _linguagemRepository = linguagemRepository;
            _arquivoIdiomaRepository = arquivoIdiomaRepository;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public async Task<LinguagemViewModel> Atualizar(LinguagemViewModel linguagemViewModel, Guid id)
        {
            var linguagem = ConvertModelMapper<Linguagem, LinguagemViewModel>(linguagemViewModel);
            if (!_notificationService.ValidEntity(linguagem))
                return null;
            
            await _linguagemRepository.AtualizarAsync(linguagem, id);
            return ConvertModelMapper<LinguagemViewModel, Linguagem>(linguagem);
        }

        public async Task<LinguagemViewModel> Inserir(LinguagemViewModel linguagemViewModel)
        {
            var linguagem = ConvertModelMapper<Linguagem, LinguagemViewModel>(linguagemViewModel);
            if (!_notificationService.ValidEntity(linguagem))
                return null;

            await _linguagemRepository.InserirAsync(linguagem);
            return ConvertModelMapper<LinguagemViewModel, Linguagem>(linguagem);
        }

        public async Task<LinguagemViewModel> ObterPorId(Guid id)
        {
            var linguagem = await _linguagemRepository.ObterPorIdAsync(id);
            return _mapper.Map<LinguagemViewModel>(linguagem);
        }

        public async Task<IEnumerable<LinguagemViewModel>> ObterTodos()
        {
            var linguagens = await _linguagemRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<LinguagemViewModel>>(linguagens);
        }

        public async Task<bool> Remover(Guid id)
        {
            return await _linguagemRepository.RemoverAsync(id);
        }

        Task<LinguagemViewModel> IServiceApp<LinguagemViewModel>.Atualizar(LinguagemViewModel model, Guid id)
        {
            throw new NotImplementedException();
        }

        Task<LinguagemViewModel> IServiceApp<LinguagemViewModel>.Inserir(LinguagemViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LinguagemViewModel>> CarregarLinguagensSemArquivoTraducaoAssociado()
        {
            var linguagensTask = _linguagemRepository.ObterTodosAsync();
            var arquivosIdiomaTask = _arquivoIdiomaRepository.ObterTodosAsync();

            var linguagens = _mapper.Map<IEnumerable<LinguagemViewModel>>(await linguagensTask);
            var arquivosIdioma = await arquivosIdiomaTask;

            return linguagens.Where(x => !arquivosIdioma.Any(y => y.Id == x.Id));
        }

        public T ConvertModelMapper<T, M>(M model)
            where T : class
            where M : class
        {
            return _mapper.Map<T>(model);
        }
    }
}
