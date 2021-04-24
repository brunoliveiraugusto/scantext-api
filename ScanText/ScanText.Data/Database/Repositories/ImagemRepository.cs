using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Data.Utils;
using ScanText.Domain.Imagem.Entities;
using ScanText.Infra.Configuration.Database.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System;

namespace ScanText.Data.Database.Repositories
{
    public class ImagemRepository : Repository<Imagem>, IImagemRepository
    {
        public ImagemRepository(ScanTextMongoContext context) : base(context)
        {

        }

        public PaginationFilter<Imagem> ObterImagensPaginadasPorIdUsuario(PaginationFilter<Imagem> pagination, Guid idUsuario)
        {
            var query = DbSet.AsQueryable().Where(imagem => imagem.IdUsuario == idUsuario);
            query = OrdenarImagem(pagination, query);
            pagination.Total = query.Count();
            pagination.Pages = query.Skip((pagination.Page - 1) * pagination.Limit).Take(pagination.Limit);
            return pagination;
        }

        public IMongoQueryable<Imagem> OrdenarImagem(PaginationFilter<Imagem> pagination, IMongoQueryable<Imagem> query)
        {
            switch(pagination.Sort)
            {
                case "nomeImagem":
                    query = pagination.Ascendant ?
                        query.OrderBy(imagem => imagem.Nome) : query.OrderByDescending(imagem => imagem.Nome);
                    break;
                case "formato":
                    query = pagination.Ascendant ?
                        query.OrderBy(imagem => imagem.Formato) : query.OrderByDescending(imagem => imagem.Formato);
                    break;
                case "tamanho":
                    query = pagination.Ascendant ?
                        query.OrderBy(imagem => imagem.Size) : query.OrderByDescending(imagem => imagem.Size);
                    break;
                case "assertividade":
                    query = pagination.Ascendant ?
                        query.OrderBy(imagem => imagem.MeanConfidence) : query.OrderByDescending(imagem => imagem.MeanConfidence);
                    break;
                case "idioma":
                    query = pagination.Ascendant ?
                        query.OrderBy(imagem => imagem.Linguagem.Idioma) : query.OrderByDescending(imagem => imagem.Linguagem.Idioma);
                    break;
                case "dataCadastro":
                    query = pagination.Ascendant ?
                        query.OrderBy(imagem => imagem.DataCadastro) : query.OrderByDescending(imagem => imagem.DataCadastro);
                    break;
                default:
                    query = pagination.Ascendant ?
                        query.OrderBy(imagem => imagem.Nome) : query.OrderByDescending(imagem => imagem.Nome);
                    break;
            }

            return query;
        }
    }
}
