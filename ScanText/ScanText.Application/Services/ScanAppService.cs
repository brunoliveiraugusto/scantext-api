using ScanText.Application.Interfaces;
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

        public string LerTextoImagem(string base64)
        {
            return _tesseractEngineOCR.ReadImage(base64);
        }
    }
}
