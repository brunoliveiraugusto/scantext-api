using ScanText.Domain.EntityDomain;
using ScanText.Domain.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Domain.Utils.Notification
{
    public class NotificationService : INotificationService
    {
        public bool ValidarEntidade<TEntity>(TEntity entity) where TEntity : Entity<TEntity>
        {
            entity.Validate();
            return true;
        }
    }
}
