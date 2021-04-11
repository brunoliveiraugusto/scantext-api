using Microsoft.Extensions.DependencyInjection;
using ScanText.Domain.Email.Entities;
using ScanText.Domain.Email.Entities.Interfaces;

namespace ScanText.Infra.Configuration.DependencyInjection.Domain
{
    public static class InjectorDomain
    {
        public static void InjectDomain(this IServiceCollection services)
        {
            services.AddSingleton<IEmailAddress, EmailAddress>();
        }
    }
}
