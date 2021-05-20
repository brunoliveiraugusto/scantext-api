using AutoMapper;
using ScanText.Application.AutoMapper;

namespace ScanText.Test.ApplicationTest.Builders.Mapper
{
    public class MapperTestBuilder : BaseTestBuilder<IMapper>
    {
        public MapperTestBuilder()
        {
            var configuration = new MapperConfiguration(x =>
            {
                x.AddProfile(new ViewModelToEntitie());
                x.AllowNullCollections = true;
                x.AllowNullDestinationValues = true;
                x.ValidateInlineMaps = false;
            });

            Model = configuration.CreateMapper();
        }
    }
}
