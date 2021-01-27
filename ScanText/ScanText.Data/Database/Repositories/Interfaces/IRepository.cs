using System;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> InserirAsync(TEntity entity);
        void Remover(Guid id);
        Task<TEntity> ObterPorIdAsync(Guid id);
        TEntity Atualizar(TEntity entity);
    }
}
