using MongoDB.Driver;
using ScanText.Infra.Configuration.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
    {
        protected readonly ScanTextMongoContext _context;
        protected IMongoCollection<TEntity> DbSet;

        public Repository(ScanTextMongoContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<TEntity>();
        }

        public virtual TEntity Atualizar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> InserirAsync(TEntity entity)
        {
            await DbSet.InsertOneAsync(entity);
            return entity;
        }

        public virtual Task<TEntity> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
