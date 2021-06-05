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
using System.Linq;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class ArquivoIdiomaAppService : IArquivoIdiomaAppService
    {
        private readonly IArquivoIdiomaRepository _arquivoIdiomaRepository;
        private readonly IFileRepository _fileRepository;
        private readonly ILinguagemRepository _linguagemRepository;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public ArquivoIdiomaAppService(IArquivoIdiomaRepository arquivoIdiomaRepository, IMapper mapper, INotificationService notificationService,
            IFileRepository fileRepository, ILinguagemRepository linguagemRepository)
        {
            _arquivoIdiomaRepository = arquivoIdiomaRepository;
            _mapper = mapper;
            _notificationService = notificationService;
            _fileRepository = fileRepository;
            _linguagemRepository = linguagemRepository;
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

        public async Task<IEnumerable<ArquivoIdiomaViewModel>> ObterTodos()
        {
            var arquivosIdioma = _mapper.Map<IEnumerable<ArquivoIdiomaViewModel>>(await _arquivoIdiomaRepository.ObterTodosAsync());

            foreach(var arquivoIdioma in arquivosIdioma)
            {
                arquivoIdioma.Idioma = await _linguagemRepository.ObterNomeIdiomaPorId(arquivoIdioma.IdIdioma);
            }

            return arquivosIdioma;
        }

        public async Task<bool> Remover(Guid id)
        {
            try
            {
                string fileName = await _arquivoIdiomaRepository.ObterNomeArquivoIdiomaPorId(id);
                await _fileRepository.Delete(fileName);
                return await _arquivoIdiomaRepository.RemoverAsync(id);
            }
            catch (Exception)
            {
                _notificationService.AddNotification("Erro ao excluir", "Erro ao tentar excluir o arquivo de idioma, por favor, tente novamente.");
                return false;
            }
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
