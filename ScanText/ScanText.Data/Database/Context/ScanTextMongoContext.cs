﻿using MongoDB.Driver;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Infra.Configuration.DataBase.Interface;

namespace ScanText.Infra.Configuration.Database.Context
{
    public class ScanTextMongoContext : IScanTextMongoContext
    {
        protected readonly IScanTextDatabaseSettings _scanTextDatabaseSettings;
        public IMongoDatabase Database { get; private set; }
        public MongoClient MongoClient { get; private set; }
        
        public ScanTextMongoContext(IScanTextDatabaseSettings scanTextDatabaseSettings)
        {
            _scanTextDatabaseSettings = scanTextDatabaseSettings;
            ConfigureMongo(_scanTextDatabaseSettings);
        }

        public IMongoCollection<Linguagem> Linguagem => GetCollection<Linguagem>();

        public void ConfigureMongo(IScanTextDatabaseSettings settings)
        {
            MongoClient = new MongoClient(settings.ConnectionString);
            Database = MongoClient.GetDatabase(settings.DatabaseName);
        }

        public virtual IMongoCollection<TEntity> GetCollection<TEntity>(string name = null)
        {
            return Database.GetCollection<TEntity>(name ?? typeof(TEntity).Name);
        }
    }
}