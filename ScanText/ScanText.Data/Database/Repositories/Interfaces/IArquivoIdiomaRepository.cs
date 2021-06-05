using ScanText.Domain.Linguagem.Entities;
using System;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IArquivoIdiomaRepository : IRepository<ArquivoIdioma>
    {
        Task<string> ObterNomeArquivoIdiomaPorId(Guid id);
    }
}
