using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ScanText.Infra.Configuration.Database.Context;
using ScanText.Infra.Configuration.DataBase;
using ScanText.Infra.Configuration.DataBase.Settings.Interfaces;

namespace ScanText.Infra.Configuration.DependencyInjection.Database
{
    public static class InjectorDatabase
    {
        public static void InjectDatabase(this IServiceCollection services)
        {
            services.AddSingleton<IScanTextDatabaseSettings>(st =>
                st.GetRequiredService<IOptions<ScanTextDatabaseSettings>>().Value);
            services.AddSingleton<ScanTextMongoContext>();
        }
    }
}
