using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Domain.Shared.Interfaces;
using ScanText.Infra.CrossCutting.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class ArquivoIdiomaAppService : IArquivoIdiomaAppService
    {
        private readonly IArquivoIdiomaRepository _arquivoIdiomaRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public ArquivoIdiomaAppService(IArquivoIdiomaRepository arquivoIdiomaRepository, IMapper mapper, INotificationService notificationService,
            IFileRepository fileRepository)
        {
            _arquivoIdiomaRepository = arquivoIdiomaRepository;
            _mapper = mapper;
            _notificationService = notificationService;
            _fileRepository = fileRepository;
        }

        public Task<ArquivoIdiomaViewModel> Atualizar(ArquivoIdiomaViewModel model, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ArquivoIdiomaViewModel> Inserir(ArquivoIdiomaViewModel model)
        {
            try
            {
                var arquivoIdioma = ConvertModelMapper<ArquivoIdioma, ArquivoIdiomaViewModel>(model);
                
                arquivoIdioma.NomeArquivoBlob = ObterNomeFisicoArquivo();
                byte[] arquivo = StringHelper.Base64ToArrayByte(model.Arquivo.Split(",")[1]);

                if (!_notificationService.ValidEntity(arquivoIdioma))
                    return null;

                arquivoIdioma.UrlArquivoBlob = await _fileRepository.Upload(arquivoIdioma.NomeArquivoBlob, arquivo);
                var arquivoResponse = await _arquivoIdiomaRepository.InserirAsync(arquivoIdioma);
                return ConvertModelMapper<ArquivoIdiomaViewModel, ArquivoIdioma>(arquivoResponse);
            }
            catch(Exception ex)
            {
                _notificationService.AddNotification("Erro ao salvar arquivo de idioma", "Erro ao tentar salvar o Arquivo de Idioma, tente novamente.");
                return null;
            }
        }

        public Task<ArquivoIdiomaViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArquivoIdiomaViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public T ConvertModelMapper<T, M>(M model)
            where T : class
            where M : class
        {
            return _mapper.Map<T>(model);
        }

        private string ObterNomeFisicoArquivo()
        {
            return $"{Guid.NewGuid()}.traineddata";
        }
    }
}
