using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class ArquivoIdiomaAppService : IArquivoIdiomaAppService
    {
        private readonly IArquivoIdiomaRepository _arquivoIdiomaRepository;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public ArquivoIdiomaAppService(IArquivoIdiomaRepository arquivoIdiomaRepository, IMapper mapper, INotificationService notificationService)
        {
            _arquivoIdiomaRepository = arquivoIdiomaRepository;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public Task<ArquivoIdiomaViewModel> Atualizar(ArquivoIdiomaViewModel model, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ArquivoIdiomaViewModel> Inserir(ArquivoIdiomaViewModel model)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
