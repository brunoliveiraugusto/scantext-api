using MongoDB.Driver.Linq;
using ScanText.Data.Utils;
using ScanText.Domain.Imagem.Entities;
using System;
using System.Linq;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IImagemRepository : IRepository<Imagem>
    {
        PaginationFilter<Imagem> ObterImagensPaginadasPorIdUsuario(PaginationFilter<Imagem> pagination, Guid idUsuario);
        IQueryable<Imagem> OrdenarImagem(PaginationFilter<Imagem> pagination, IQueryable<Imagem> query);
    }
}
