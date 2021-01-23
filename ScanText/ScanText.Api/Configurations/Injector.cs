using Microsoft.Extensions.DependencyInjection;
using ScanText.Application.Interfaces;
using ScanText.Application.Services;

namespace ScanText.Api.Configurations
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Service
            services.AddScoped<IScanAppService, ScanAppService>();
        }
    }
}
