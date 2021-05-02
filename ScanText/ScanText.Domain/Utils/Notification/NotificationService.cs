using ScanText.Domain.EntityDomain;
using ScanText.Domain.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
