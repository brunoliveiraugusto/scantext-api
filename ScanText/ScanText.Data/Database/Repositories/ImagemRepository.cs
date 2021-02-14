using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Data.Utils;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Infra.Configuration.Database.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;

namespace ScanText.Data.Database.Repositories
{
    public class ImagemRepository : Repository<Imagem>, IImagemRepository
    {
        public ImagemRepository(ScanTextMongoContext context) : base(context)
        {

        }

        public PaginationFilter<Imagem> ObterImagensPaginadas(PaginationFilter<Imagem> pagination)
        {
            var query = DbSet.AsQueryable();
            pagination.Total = query.Count();
            pagination.Pages = query.Skip(pagination.Skip).Take(pagination.Take);
            return pagination;
        }
    }
}
