using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScanText.Data.Database.Settings;
using ScanText.Data.Settings;
using ScanText.Infra.Configuration.DataBase;
using ScanText.Infra.CrossCutting.Settings;
using ScanText.Security.Authentication.Settings;

namespace ScanText.Infra.Configuration.AppSettings
{
    public static class AppSettingsConfiguration
    {
        public static IServiceCollection AddAppSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ScanTextDatabaseSettings>(
                configuration.GetSection(nameof(ScanTextDatabaseSettings)));

            services.Configure<TokenSettings>(
                configuration.GetSection(nameof(TokenSettings)));

            services.Configure<SendGridSettings>(
                configuration.GetSection(nameof(SendGridSettings)));

            services.Configure<StorageAzureSettings>(
                configuration.GetSection(nameof(StorageAzureSettings)));

            services.Configure<ScanTextClientSettings>(
                configuration.GetSection(nameof(ScanTextClientSettings)));

            return services;
        }
    }
}
