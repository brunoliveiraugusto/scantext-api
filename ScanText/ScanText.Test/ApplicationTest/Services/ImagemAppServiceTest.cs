using AutoMapper;
using FluentAssertions;
using Moq;
using ScanText.Application.Services;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Test.ApplicationTest.Builders.Domain;
using ScanText.Test.ApplicationTest.Builders.Mapper;
using ScanText.Test.ApplicationTest.Builders.Repository;
using ScanText.Test.ApplicationTest.Builders.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScanText.Test.ApplicationTest.Services
{
    public class ImagemAppServiceTest
    {
        private Mock<IImagemRepository> _imagemRepositoryMock = new ImagemRepositoryTestBuilder().Build();
        private IMapper _mapper = new MapperTestBuilder().Build();
        private Imagem _imagemMock = new ImagemTestBuilder().Default().Build();

        private ImagemAppService BuildConstructor()
        {
            return new ImagemAppService(_imagemRepositoryMock.Object, _mapper);
        }

        [Fact(DisplayName = "Teste de inserção de uma imagem")]
        public async void InserirTest()
        {
            #region Given
            ImagemAppService imagemAppService = BuildConstructor();

            _imagemRepositoryMock
                .Setup(s => s.InserirAsync(It.IsAny<Imagem>()))
                .Returns(Task.FromResult(_imagemMock));
            #endregion

            #region When
            var imagemVM = new ImagemViewModelTestBuilder().Default().Build();

            var resp = await imagemAppService.InserirAsync(imagemVM);
            #endregion

            #region Then
            resp.Should().BeTrue();
            #endregion
        }
    }
}
