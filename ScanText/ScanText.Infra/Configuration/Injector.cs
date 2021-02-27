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
using ScanText.Security.Authentication;
using ScanText.Security.Authentication.Interfaces;
using ScanText.Security.Authentication.Settings;
using ScanText.Security.Encrypt;
using ScanText.Security.Encrypt.Interfaces;

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

            //Engine
            services.AddScoped<ITesseractEngineOCR, TesseractEngineOCR>();

            //Repositories
            services.AddScoped<ILinguagemRepository, LinguagemRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Database
            services.AddSingleton<IScanTextDatabaseSettings>(st =>
                st.GetRequiredService<IOptions<ScanTextDatabaseSettings>>().Value);

            //Security
            services.AddSingleton<IEncryptData, EncryptData>();
            services.AddSingleton<IToken, Token>();
            services.AddSingleton<ITokenSettings>(st =>
                st.GetRequiredService<IOptions<TokenSettings>>().Value);

            services.AddSingleton<ScanTextMongoContext>();
        }
    }
}
