using AutoMapper;
using Moq;
using ScanText.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Test.ApplicationTest.Builders.Mapper
{
    public class MapperTestBuilder
    {
        protected IMapper Model;

        public MapperTestBuilder()
        {
            var configuration = new MapperConfiguration(x =>
            {
                x.AddProfile(new ViewModelToEntitie());
                x.AllowNullCollections = true;
                x.AllowNullDestinationValues = true;
            });

            Model = configuration.CreateMapper();
        }

        public IMapper Build()
        {
            return Model;
        }
    }
}
