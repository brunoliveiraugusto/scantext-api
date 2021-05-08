using Moq;
using ScanText.Domain.Shared.Interfaces;
using ScanText.Domain.Shared.Notification;

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
