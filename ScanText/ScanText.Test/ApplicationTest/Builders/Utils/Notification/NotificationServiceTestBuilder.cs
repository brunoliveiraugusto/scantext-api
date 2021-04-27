using Moq;
using ScanText.Domain.Utils.Interfaces;
using ScanText.Domain.Utils.Notification;

namespace ScanText.Test.ApplicationTest.Builders.Utils.Notification
{
    public class NotificationServiceTestBuilder : BaseTestBuilder<NotificationService>
    {
        public NotificationServiceTestBuilder()
        {
            Model = new NotificationService();
        }
    }
}
