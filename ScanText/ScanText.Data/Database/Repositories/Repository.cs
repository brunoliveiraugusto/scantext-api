using MongoDB.Driver;
using ScanText.Domain.BaseDomain;
using ScanText.Infra.Configuration.Database.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected readonly ScanTextMongoContext _context;
        protected IMongoCollection<TEntity> DbSet;

        public Repository(ScanTextMongoContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<TEntity>();
        }

        public virtual async Task<TEntity> AtualizarAsync(TEntity entity, Guid id)
        {
            await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", id), entity);
            return entity;
        }

        public virtual async Task<TEntity> InserirAsync(TEntity entity)
        {
            entity.Id = new Guid();
            await DbSet.InsertOneAsync(entity);
            return entity;
        }

        public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
        {
            var entity = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return entity.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task<bool> RemoverAsync(Guid id)
        {
            var resp = await DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return resp.DeletedCount > 0;
        }
    }
}
