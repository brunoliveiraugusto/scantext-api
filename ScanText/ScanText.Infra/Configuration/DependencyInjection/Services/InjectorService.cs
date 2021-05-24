using Microsoft.Extensions.DependencyInjection;
using ScanText.Application.Interfaces;
using ScanText.Application.Services;
using ScanText.Security.Authentication.Interfaces;
using ScanText.Security.Authentication.Services;

namespace ScanText.Infra.Configuration.DependencyInjection.Services
{
    public static class InjectorService
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IScanAppService, ScanAppService>();
            services.AddScoped<ILinguagemAppService, LinguagemAppService>();
            services.AddScoped<IImagemAppService, ImagemAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPerfilAppService, PerfilAppService>();
            services.AddScoped<IArquivoIdiomaAppService, ArquivoIdiomaAppService>();
        }
    }
}
