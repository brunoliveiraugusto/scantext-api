using MongoDB.Driver.Linq;
using ScanText.Data.Utils;
using ScanText.Domain.Linguagem.Entities;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IImagemRepository : IRepository<Imagem>
    {
        PaginationFilter<Imagem> ObterImagensPaginadas(PaginationFilter<Imagem> pagination);
        IMongoQueryable<Imagem> OrdenarImagem(PaginationFilter<Imagem> pagination, IMongoQueryable<Imagem> query);
    }
}
