using Microsoft.Extensions.DependencyInjection;
using ScanText.Domain.Email.Entities;
using ScanText.Domain.Email.Entities.Interfaces;
using ScanText.Domain.Shared.Interfaces;
using ScanText.Domain.Shared.Notification;

namespace ScanText.Infra.Configuration.DependencyInjection.Domain
{
    public static class InjectorDomain
    {
        public static void InjectDomain(this IServiceCollection services)
        {
            services.AddSingleton<IEmailAddress, EmailAddress>();
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
