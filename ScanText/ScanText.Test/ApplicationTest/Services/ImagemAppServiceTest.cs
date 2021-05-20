using AutoMapper;
using FluentAssertions;
using Moq;
using ScanText.Application.Services;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Imagem.Entities;
using ScanText.Domain.Shared.Notification;
using ScanText.Security.Authentication.Interfaces;
using ScanText.Test.ApplicationTest.Builders.Domain;
using ScanText.Test.ApplicationTest.Builders.Mapper;
using ScanText.Test.ApplicationTest.Builders.Repository;
using ScanText.Test.ApplicationTest.Builders.Utils.Notification;
using ScanText.Test.ApplicationTest.Builders.ViewModel;
using System.Threading.Tasks;
using Xunit;

namespace ScanText.Test.ApplicationTest.Services
{
    public class ImagemAppServiceTest
    {
        private Mock<IImagemRepository> _imagemRepositoryMock = new ImagemRepositoryTestBuilder().Build();
        private IMapper _mapper = new MapperTestBuilder().Build();
        private Imagem _imagemMock = new ImagemTestBuilder().Default().Build();
        private Mock<IUsuarioService> _userMock = new UsuarioServiceTestBuilder().Build();
        private Mock<IFileRepository> _fileMock = new FileRepositoryTestBuilder().Build();
        private NotificationService _notificationService = new NotificationServiceTestBuilder().Build();
        private readonly string _urlImageBlobStorage = "https://storagescantext.blob.core.windows.net/containerscantext/e455341a-44b3-4ee0-8e7a-de2263cd3d61.png";

        private ImagemAppService BuildConstructor()
        {
            return new ImagemAppService(_imagemRepositoryMock.Object, _mapper, _userMock.Object, null, null, null, _notificationService, _fileMock.Object);
        }

        [Fact(DisplayName = "Teste de inserção de uma imagem")]
        public async void InserirTest()
        {
            #region Given
            ImagemAppService imagemAppService = BuildConstructor();

            _imagemRepositoryMock
                .Setup(s => s.InserirAsync(It.IsAny<Imagem>()))
                .Returns(Task.FromResult(_imagemMock));

            _fileMock
                .Setup(s => s.Upload(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(Task.FromResult(_urlImageBlobStorage));
            #endregion

            #region When
            var imagemVM = new ImagemViewModelTestBuilder().DefaultIdiomaPortugues().Build();

            var resp = await imagemAppService.Inserir(imagemVM);
            #endregion

            #region Then
            resp.Should().NotBeNull();
            resp.Formato.Should().BeEquivalentTo("imagem/png");
            resp.Nome.Should().BeEquivalentTo("imagem texto");
            resp.Size.Should().BeGreaterThan(0);
            resp.Size.Should().Be(123232);
            resp.Texto.Should().BeEquivalentTo("Texto da imagem de teste");
            resp.MeanConfidence.Should().BeGreaterThan(0);
            resp.MeanConfidence.Should().Be(99.5f);
            resp.Linguagem.Should().NotBeNull();
            resp.UrlImagemBlob.Should().NotBeNullOrWhiteSpace();
            resp.NomeImagemBlob.Should().NotBeNullOrWhiteSpace();
            #endregion
        }
    }
}
