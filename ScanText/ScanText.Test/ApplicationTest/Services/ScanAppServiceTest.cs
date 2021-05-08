using AutoMapper;
using FluentAssertions;
using Moq;
using ScanText.Application.Services;
using ScanText.Engine.Tesseract.Interfaces;
using ScanText.Engine.Tesseract.Models;
using ScanText.Test.ApplicationTest.Builders.Domain;
using ScanText.Test.ApplicationTest.Builders.Mapper;
using ScanText.Test.ApplicationTest.Builders.Repository;
using ScanText.Test.ApplicationTest.Builders.ViewModel;
using Xunit;

namespace ScanText.Test.ApplicationTest.Services
{
    public class ScanAppServiceTest
    {
        private Mock<ITesseractEngineRepository> _tesseractEngineRepositoryMock = new TesseractEngineRepositoryTestBuilder().Build();
        private TesseractImage _tesseractImage = new TesseractImageTestBuilder().Default().Build();
        private IMapper _mapper = new MapperTestBuilder().Build();

        private ScanAppService BuildConstructor()
        {
            return new ScanAppService(_tesseractEngineRepositoryMock.Object, null, _mapper);
        }

        [Fact(DisplayName = "Teste de leitura de imagem no idioma português")]
        public void LerImagemTest()
        {
            #region Given
            ScanAppService scanAppService = BuildConstructor();

            _tesseractEngineRepositoryMock
                .Setup(s => s.ReadImage(It.IsAny<TesseractImage>()))
                .Returns(_tesseractImage);
            #endregion

            #region When
            var imagemVM = new ImagemTesseractViewModelTestBuilder().DefaultIdiomaPortugues().Build();
            var resp = scanAppService.LerTextoImagem(imagemVM);
            #endregion

            #region Then
            resp.Should().NotBeNull();
            resp.Texto.Should().NotBeNullOrEmpty();
            resp.MeanConfidence.Should().BeGreaterOrEqualTo(0.0f);
            #endregion
        }

        [Fact(DisplayName = "Teste de leitura de imagem no idioma inglês")]
        public void LerImagemIdiomaInglesTest()
        {
            #region Given
            ScanAppService scanAppService = BuildConstructor();

            _tesseractEngineRepositoryMock
                .Setup(s => s.ReadImage(It.IsAny<TesseractImage>()))
                .Returns(_tesseractImage);
            #endregion

            #region When
            var imagemVM = new ImagemTesseractViewModelTestBuilder().DefaultIdiomaPortugues().Build();
            var resp = scanAppService.LerTextoImagem(imagemVM);
            #endregion

            #region Then
            resp.Should().NotBeNull();
            resp.Texto.Should().NotBeNullOrEmpty();
            resp.MeanConfidence.Should().BeGreaterOrEqualTo(0.0f);
            #endregion
        }

    }
}
