using ScanText.Domain.Linguagem.Entities;
using System;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface ILinguagemRepository : IRepository<Linguagem>
    {
        Task<string> ObterNomeIdiomaPorId(Guid id);
    }
}
