using MongoDB.Driver.Linq;
using ScanText.Data.Utils;
using ScanText.Domain.Imagem.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IImagemRepository : IRepository<Imagem>
    {
        PaginationFilter<Imagem> ObterImagensPaginadasPorIdUsuario(PaginationFilter<Imagem> pagination, Guid idUsuario);
        IQueryable<Imagem> OrdenarImagem(PaginationFilter<Imagem> pagination, IQueryable<Imagem> query);
        Task<string> ObterNomeImagemBlobPorId(Guid id);
    }
}
