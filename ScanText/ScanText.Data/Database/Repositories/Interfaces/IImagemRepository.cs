using MongoDB.Driver.Linq;
using ScanText.Data.Utils;
using ScanText.Domain.Linguagem.Entities;
using System;
using System.Collections.Generic;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IImagemRepository : IRepository<Imagem>
    {
        PaginationFilter<Imagem> ObterImagensPaginadasPorIdUsuario(PaginationFilter<Imagem> pagination, Guid idUsuario);
        IMongoQueryable<Imagem> OrdenarImagem(PaginationFilter<Imagem> pagination, IMongoQueryable<Imagem> query);
    }
}
