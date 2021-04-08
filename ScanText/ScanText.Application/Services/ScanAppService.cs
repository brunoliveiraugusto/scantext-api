using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Engine.Tesseract.Models;
using ScanText.Engine.Tesseract.Interfaces;
using ScanText.Engine.Interfaces;

namespace ScanText.Application.Services
{
    public class ScanAppService : IScanAppService
    {
        private readonly ITesseractEngineService _tesseractEngineService;
        private readonly IQrCodeGeneratorService _qrCodeGeneratorService;
        private readonly IMapper _mapper;

        public ScanAppService(ITesseractEngineService tesseractEngineService, IQrCodeGeneratorService qrCodeGeneratorService, IMapper mapper)
        {
            _tesseractEngineService = tesseractEngineService;
            _qrCodeGeneratorService = qrCodeGeneratorService;
            _mapper = mapper;
        }

        public ImagemViewModel LerTextoImagem(ImagemViewModel imagemVM)
        {
            var imagemOCR = _mapper.Map<TesseractImage>(imagemVM);
            imagemOCR = _tesseractEngineService.ReadImage(imagemOCR);
            imagemVM = _mapper.Map<TesseractImage, ImagemViewModel>(imagemOCR, imagemVM);
            return imagemVM;
        }

        public QrCodeResponseViewModel ObterQrCodeImagem(string text)
        {
            var qrCode = _qrCodeGeneratorService.GenerateQrCode(text);
            return _mapper.Map<QrCodeResponseViewModel>(qrCode);
        }
    }
}
