using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> InserirAsync(TEntity entity);
        Task<bool> RemoverAsync(Guid id);
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task<TEntity> AtualizarAsync(TEntity entity, Guid id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
    }
}
