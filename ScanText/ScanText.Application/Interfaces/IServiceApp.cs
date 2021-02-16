using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface IServiceApp<TEntity>
    {
        Task AtualizarAsync(TEntity model, Guid id);
        Task InserirAsync(TEntity model);
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task RemoverAsync(Guid id);
    }
}
