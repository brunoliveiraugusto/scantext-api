using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ScanText.Application.Interfaces;
using ScanText.Application.Services;
using ScanText.Engine.Tesseract.Entities;
using ScanText.Engine.Tesseract.Interfaces;
using ScanText.Infra.Configuration.Database.Context;
using ScanText.Infra.Configuration.DataBase;
using ScanText.Infra.Configuration.DataBase.Interface;

namespace ScanText.Api.Configurations
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Service
            services.AddScoped<IScanAppService, ScanAppService>();

            //Engine
            services.AddScoped<ITesseractEngineOCR, TesseractEngineOCR>();

            //Database
            services.AddSingleton<IScanTextDatabaseSettings>(st =>
                st.GetRequiredService<IOptions<ScanTextDatabaseSettings>>().Value);

            services.AddSingleton<ScanTextMongoContext>();
        }
    }
}
