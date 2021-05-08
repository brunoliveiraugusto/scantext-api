using ScanText.Domain.BaseDomain;
using ScanText.Domain.Shared.Notification;
using System.Collections.Generic;

namespace ScanText.Domain.Shared.Interfaces
{
    public interface INotificationService
    {
        public List<NotificationItem> Notifications { get; set; }
        public bool ValidEntity<TEntity>(TEntity entity) where TEntity : Entity<TEntity>;
        public void AddNotification(string key, string value);
    }
}
