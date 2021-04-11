using Microsoft.Extensions.DependencyInjection;

namespace ScanText.Infra.Configurations.DependencyInjection
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            Injector.RegisterServices(services);
        }
    }
}
