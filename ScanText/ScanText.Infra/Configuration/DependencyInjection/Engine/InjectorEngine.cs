using Microsoft.Extensions.DependencyInjection;
using ScanText.Engine.Interfaces;
using ScanText.Engine.Repositories;
using ScanText.Engine.Tesseract.Interfaces;
using ScanText.Engine.Tesseract.Repositories;

namespace ScanText.Infra.Configuration.DependencyInjection.Engine
{
    public static class InjectorEngine
    {
        public static void InjectEngine(this IServiceCollection services)
        {
            services.AddScoped<ITesseractEngineRepository, TesseractEngineRepository>();
            services.AddScoped<IQrCodeGeneratorRepository, QrCodeGeneratorRepository>();
        }
    }
}
