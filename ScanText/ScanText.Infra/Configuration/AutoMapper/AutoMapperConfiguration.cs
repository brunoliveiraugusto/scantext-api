using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ScanText.Application.AutoMapper;

namespace ScanText.Infra.Configuration.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntitieToViewModel());
                mc.AddProfile(new ViewModelToEntitie());
                mc.AllowNullCollections = true;
                mc.AllowNullDestinationValues = true;
                mc.ValidateInlineMaps = false;
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            return services;
        }
    }
}
