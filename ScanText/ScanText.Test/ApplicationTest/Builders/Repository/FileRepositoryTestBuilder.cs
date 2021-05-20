using Moq;
using ScanText.Data.Database.Repositories.Interfaces;

namespace ScanText.Test.ApplicationTest.Builders.Repository
{
    public class FileRepositoryTestBuilder : BaseTestBuilder<Mock<IFileRepository>>
    {
        public FileRepositoryTestBuilder()
        {
            Model = new Mock<IFileRepository>();
        }
    }
}
