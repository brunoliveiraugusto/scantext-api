using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Imagem.Entities;
using ScanText.Infra.Configuration.Database.Context;

namespace ScanText.Data.Database.Repositories
{
    public class LinguagemRepository : Repository<Linguagem>, ILinguagemRepository
    {
        public LinguagemRepository(ScanTextMongoContext context) : base(context)
        {

        }
    }
}
