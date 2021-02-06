using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Engine.Tesseract.Interfaces;

namespace ScanText.Application.Services
{
    public class ScanAppService : IScanAppService
    {
        private readonly ITesseractEngineOCR _tesseractEngineOCR;

        public ScanAppService(ITesseractEngineOCR tesseractEngineOCR)
        {
            _tesseractEngineOCR = tesseractEngineOCR;
        }

        public ImagemViewModel LerTextoImagem(ImagemViewModel imagem)
        {
            imagem.Texto = _tesseractEngineOCR.ReadImage(imagem.Base64);
            return imagem;
        }
    }
}
