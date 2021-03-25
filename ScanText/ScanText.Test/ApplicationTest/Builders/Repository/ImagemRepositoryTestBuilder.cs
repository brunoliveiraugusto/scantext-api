using Moq;
using ScanText.Data.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Test.ApplicationTest.Builders.Repository
{
    public class ImagemRepositoryTestBuilder
    {
        protected Mock<IImagemRepository> Model;

        public ImagemRepositoryTestBuilder()
        {
            Model = new Mock<IImagemRepository>();
        }

        public Mock<IImagemRepository> Build()
        {
            return Model;
        }
    }
}
