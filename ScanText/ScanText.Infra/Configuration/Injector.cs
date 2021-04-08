using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ScanText.Application.Interfaces;
using ScanText.Application.Services;
using ScanText.Data.Database.Repositories;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Engine.Tesseract.Entities;
using ScanText.Engine.Tesseract.Interfaces;
using ScanText.Infra.Configuration.Database.Context;
using ScanText.Infra.Configuration.DataBase;
using ScanText.Infra.Configuration.DataBase.Interface;
using ScanText.Security.Authentication.Services;
using ScanText.Security.Authentication.Interfaces;
using ScanText.Security.Authentication.Settings;
using ScanText.Security.Encrypt;
using ScanText.Security.Encrypt.Interfaces;
using Microsoft.AspNetCore.Http;
using ScanText.Domain.Email.Entities;
using ScanText.Domain.Email.Entities.Interfaces;

namespace ScanText.Api.Configurations
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Service
            services.AddScoped<IScanAppService, ScanAppService>();
            services.AddScoped<ILinguagemAppService, LinguagemAppService>();
            services.AddScoped<IImagemAppService, ImagemAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPerfilAppService, PerfilAppService>();

            //Engine
            services.AddScoped<ITesseractEngineOCR, TesseractEngineOCR>();

            //Repositories
            services.AddScoped<ILinguagemRepository, LinguagemRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();

            //Database
            services.AddSingleton<IScanTextDatabaseSettings>(st =>
                st.GetRequiredService<IOptions<ScanTextDatabaseSettings>>().Value);

            //Security
            services.AddSingleton<IEncryptData, EncryptData>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<ITokenSettings>(st =>
                st.GetRequiredService<IOptions<TokenSettings>>().Value);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Domain
            services.AddSingleton<IEmailAddress, EmailAddress>();

            services.AddSingleton<ScanTextMongoContext>();
        }
    }
}
