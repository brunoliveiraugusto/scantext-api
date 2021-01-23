using Microsoft.Extensions.DependencyInjection;
using ScanText.Application.Interfaces;
using ScanText.Application.Services;
using ScanText.Engine.Tesseract.Entities;
using ScanText.Engine.Tesseract.Interfaces;

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
        }
    }
}
