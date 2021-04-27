using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface IServiceApp<TEntity>
    {
        Task<TEntity> Atualizar(TEntity model, Guid id);
        Task<TEntity> Inserir(TEntity model);
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<bool> Remover(Guid id);
        T ConvertModelMapper<T, M>(M model)
            where T : class
            where M : class;
    }
}
