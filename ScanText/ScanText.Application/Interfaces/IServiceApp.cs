using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface IServiceApp<TEntity>
    {
        Task Atualizar(TEntity model, Guid id);
        Task<bool> Inserir(TEntity model);
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task Remover(Guid id);
    }
}
