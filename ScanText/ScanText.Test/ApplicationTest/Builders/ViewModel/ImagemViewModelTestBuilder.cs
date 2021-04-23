using ScanText.Application.ViewModels;
using System;

namespace ScanText.Test.ApplicationTest.Builders.ViewModel
{
    public class ImagemViewModelTestBuilder : BaseTestBuilder<ImagemViewModel>
    {
        public ImagemViewModelTestBuilder()
        {
            Model = new ImagemViewModel();
        }

        public ImagemViewModelTestBuilder DefaultIdiomaPortugues()
        {
            Model.Base64 = "base64,f0adfasdfjasdhfosaiyf9sa86f";
            Model.DataCadastro = DateTime.Now;
            Model.Formato = "png";
            Model.Id = Guid.NewGuid();
            Model.Linguagem = new LinguagemViewModel { Sigla = "pt", Id = Guid.NewGuid(), DataCadastro = DateTime.Now.AddMonths(-2), Idioma = "Português" };
            Model.MeanConfidence = 99.5f;
            Model.Nome = "imagem texto";
            Model.Size = 123232;
            Model.Texto = "Texto da imagem de teste";

            return this;
        }

        public ImagemViewModelTestBuilder DefaultIdiomaIngles()
        {
            Model.Base64 = "base64,f0adfasdfjasdhfosaiyf9sa86f";
            Model.DataCadastro = DateTime.Now;
            Model.Formato = "png";
            Model.Id = Guid.NewGuid();
            Model.Linguagem = new LinguagemViewModel { Sigla = "pt", Id = Guid.NewGuid(), DataCadastro = DateTime.Now.AddMonths(-2), Idioma = "Inglês" };
            Model.MeanConfidence = 99.5f;
            Model.Nome = "imagem texto";
            Model.Size = 123232;
            Model.Texto = "Texto da imagem de teste";

            return this;
        }
    }
}
