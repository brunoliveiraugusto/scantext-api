using ScanText.Domain.EntityDomain;
using ScanText.Domain.Utils.Notification;
using System.Collections.Generic;

namespace ScanText.Domain.Utils.Interfaces
{
    public interface INotificationService
    {
        public List<NotificationItem> Notifications { get; set; }
        public bool ValidEntity<TEntity>(TEntity entity) where TEntity : Entity<TEntity>;
        public void AddNotification(string key, string value);
    }
}
