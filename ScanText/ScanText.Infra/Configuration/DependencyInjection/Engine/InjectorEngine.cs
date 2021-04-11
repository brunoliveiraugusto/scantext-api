using Microsoft.Extensions.DependencyInjection;
using ScanText.Engine.Interfaces;
using ScanText.Engine.Services;
using ScanText.Engine.Tesseract.Interfaces;
using ScanText.Engine.Tesseract.Services;

namespace ScanText.Infra.Configuration.DependencyInjection.Engine
{
    public static class InjectorEngine
    {
        public static void InjectEngine(this IServiceCollection services)
        {
            services.AddScoped<ITesseractEngineService, TesseractEngineService>();
            services.AddScoped<IQrCodeGeneratorService, QrCodeGeneratorService>();
        }
    }
}
