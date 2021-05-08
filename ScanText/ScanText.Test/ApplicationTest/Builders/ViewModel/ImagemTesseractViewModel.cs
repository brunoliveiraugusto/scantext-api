using ScanText.Application.ViewModels;

namespace ScanText.Test.ApplicationTest.Builders.ViewModel
{
    public class ImagemTesseractViewModelTestBuilder : BaseTestBuilder<ImagemTesseractViewModel>
    {
        public ImagemTesseractViewModelTestBuilder()
        {
            Model = new ImagemTesseractViewModel();
        }

        public ImagemTesseractViewModelTestBuilder DefaultIdiomaPortugues()
        {
            Model.Base64 = "base64,f0adfasdfjasdhfosaiyf9sa86f";
            Model.SiglaLinguagem = "pt";
            return this;
        }

        public ImagemTesseractViewModelTestBuilder DefaultIdiomaIngles()
        {
            Model.Base64 = "base64,f0adfasdfjasdhfosaiyf9sa86f";
            Model.SiglaLinguagem = "en";
            return this;
        }
    }
}
