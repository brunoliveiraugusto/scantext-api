using Microsoft.Extensions.DependencyInjection;
using ScanText.Infra.Configuration.DependencyInjection.Services;
using ScanText.Infra.Configuration.DependencyInjection.Repositories;
using ScanText.Infra.Configuration.DependencyInjection.Security;
using ScanText.Infra.Configuration.DependencyInjection.Database;
using ScanText.Infra.Configuration.DependencyInjection.Domain;
using ScanText.Infra.Configuration.DependencyInjection.Engine;

namespace ScanText.Infra.Configurations.DependencyInjection
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            InjectorService.InjectServices(services);
            InjectorRepository.InjectRepositories(services);
            InjectorDatabase.InjectDatabase(services);
            InjectorSecurity.InjectSecutiry(services);
            InjectorDomain.InjectDomain(services);
            InjectorEngine.InjectEngine(services);
        }
    }
}
