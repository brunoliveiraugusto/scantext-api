using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Infra.Configuration.Database.Context;

namespace ScanText.Data.Database.Repositories
{
    public class ImagemRepository : Repository<Imagem>, IImagemRepository
    {
        public ImagemRepository(ScanTextMongoContext context) : base(context)
        {

        }
    }
}
