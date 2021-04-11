using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ScanText.Security.Authentication.Interfaces;
using ScanText.Security.Authentication.Services;
using ScanText.Security.Authentication.Settings;
using ScanText.Security.Encrypt;
using ScanText.Security.Encrypt.Interfaces;

namespace ScanText.Infra.Configuration.DependencyInjection.Security
{
    public static class InjectorSecurity
    {
        public static void InjectSecutiry(this IServiceCollection services)
        {
            services.AddSingleton<IEncryptData, EncryptData>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<ITokenSettings>(st =>
                st.GetRequiredService<IOptions<TokenSettings>>().Value);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
