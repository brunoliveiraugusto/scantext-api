using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ScanText.Infra.Configurations.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ScanText.Infra.Configuration.Swagger;
using ScanText.Infra.Configuration.AutoMapper;
using ScanText.Infra.Configuration.AppSettings;
using ScanText.Infra.Configuration.Authentication;
using ScanText.Infra.Configuration.Cors;
using ScanText.Api.Configuration;

namespace ScanText.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAppSettingsConfiguration(Configuration);
            services.AddSwaggerConfiguration();
            services.AddAutoMapperConfiguration();
            services.AddAuthenticationConfiguration(Configuration);
            services.AddCorsConfiguration(MyAllowSpecificOrigins);
            services.AddDIConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApiConfiguration(env, MyAllowSpecificOrigins);
        }
    }
}
