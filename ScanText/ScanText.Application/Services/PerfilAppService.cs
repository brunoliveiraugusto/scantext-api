using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class PerfilAppService : IPerfilAppService
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilAppService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public Task<PerfilViewModel> Atualizar(PerfilViewModel model, Guid id)
        {
            throw new NotImplementedException();
        }

        public T ConvertModelMapper<T, M>(M model)
            where T : class
            where M : class
        {
            throw new NotImplementedException();
        }

        public Task<PerfilViewModel> Inserir(PerfilViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PerfilViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PerfilViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
