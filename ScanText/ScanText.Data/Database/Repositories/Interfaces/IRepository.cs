using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> InserirAsync(TEntity entity);
        Task RemoverAsync(Guid id);
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task<TEntity> AtualizarAsync(TEntity entity);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
    }
}
