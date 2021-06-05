using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Infra.Configuration.Database.Context;
using System;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories
{
    public class ArquivoIdiomaRepository : Repository<ArquivoIdioma>, IArquivoIdiomaRepository
    {
        public ArquivoIdiomaRepository(ScanTextMongoContext context) : base(context)
        {

        }

        public async Task<string> ObterNomeArquivoIdiomaPorId(Guid id)
        {
            return await DbSet.AsQueryable().Where(arquivo => arquivo.Id == id).Select(arquivo => arquivo.NomeArquivoBlob).FirstOrDefaultAsync();
        }
    }
}
