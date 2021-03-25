using Moq;
using ScanText.Data.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Test.ApplicationTest.Builders.Repository
{
    public class ImagemRepositoryTestBuilder : BaseTestBuilder<Mock<IImagemRepository>>
    {
        public ImagemRepositoryTestBuilder()
        {
            Model = new Mock<IImagemRepository>();
        }
    }
}
