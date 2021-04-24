using ScanText.Domain.EntityDomain;

namespace ScanText.Domain.Utils.Interfaces
{
    public interface INotificationService
    {
        public bool ValidarEntidade<TEntity>(TEntity entity) where TEntity : Entity<TEntity>;
    }
}
