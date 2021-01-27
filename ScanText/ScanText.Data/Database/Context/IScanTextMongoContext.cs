using MongoDB.Driver;
using ScanText.Infra.Configuration.DataBase.Interface;

namespace ScanText.Infra.Configuration.Database.Context
{
    public interface IScanTextMongoContext
    {
        void ConfigureMongo(IScanTextDatabaseSettings settings);
        IMongoCollection<TEntity> GetCollection<TEntity>(string name = null);
    }
}
