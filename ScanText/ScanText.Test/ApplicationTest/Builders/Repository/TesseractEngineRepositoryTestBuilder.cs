using Moq;
using ScanText.Engine.Tesseract.Interfaces;

namespace ScanText.Test.ApplicationTest.Builders.Repository
{
    public class TesseractEngineRepositoryTestBuilder : BaseTestBuilder<Mock<ITesseractEngineRepository>>
    {
        public TesseractEngineRepositoryTestBuilder()
        {
            Model = new Mock<ITesseractEngineRepository>();
        }
    }
}
