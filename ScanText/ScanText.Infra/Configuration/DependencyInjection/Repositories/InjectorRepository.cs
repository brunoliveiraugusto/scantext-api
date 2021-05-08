using Microsoft.Extensions.DependencyInjection;
using ScanText.Data.Database.Repositories;
using ScanText.Data.Database.Repositories.Interfaces;

namespace ScanText.Infra.Configuration.DependencyInjection.Repositories
{
    public static class InjectorRepository
    {
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILinguagemRepository, LinguagemRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
        }
    }
}
