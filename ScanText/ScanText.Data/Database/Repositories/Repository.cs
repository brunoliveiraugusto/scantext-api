﻿using MongoDB.Driver;
using ScanText.Domain.DomainObjects;
using ScanText.Infra.Configuration.Database.Context;
using System;
using System.Collections;
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

        public virtual async Task<TEntity> AtualizarAsync(TEntity entity)
        {
            await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id), entity);
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

        public virtual async Task RemoverAsync(Guid id)
        {
            await DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
        }
    }
}
