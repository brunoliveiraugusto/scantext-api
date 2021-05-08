using ScanText.Domain.BaseDomain;
using ScanText.Domain.Utils.Interfaces;
using System.Collections.Generic;

namespace ScanText.Domain.Utils.Notification
{
    public class NotificationService : INotificationService
    {
        public List<NotificationItem> Notifications { get; set; }

        public NotificationService()
        {
            Notifications = new List<NotificationItem>();
        }

        public bool ValidEntity<TEntity>(TEntity entity) where TEntity : Entity<TEntity>
        {
            entity.Validate();
            return true;
        }

        public void AddNotification(string key, string value)
        {
            Notifications.Add(new NotificationItem(key, value).GetNotificationItem());
        }
    }
}
