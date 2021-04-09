using MongoDB.Driver;
using ScanText.Infra.Configuration.DataBase.Settings.Interfaces;

namespace ScanText.Infra.Configuration.Database.Context.Interfaces
{
    public interface IScanTextMongoContext
    {
        void ConfigureMongo(IScanTextDatabaseSettings settings);
        IMongoCollection<TEntity> GetCollection<TEntity>(string name = null);
    }
}
