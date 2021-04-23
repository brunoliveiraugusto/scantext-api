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
        private readonly ITesseractEngineRepository _tesseractEngineRepository;
        private readonly IQrCodeGeneratorRepository _qrCodeGeneratorRepository;
        private readonly IMapper _mapper;

        public ScanAppService(ITesseractEngineRepository tesseractEngineRepository, IQrCodeGeneratorRepository qrCodeGeneratorRepository, IMapper mapper)
        {
            _tesseractEngineRepository = tesseractEngineRepository;
            _qrCodeGeneratorRepository = qrCodeGeneratorRepository;
            _mapper = mapper;
        }

        public ImagemViewModel LerTextoImagem(ImagemViewModel imagemVM)
        {
            var imagemOCR = _mapper.Map<TesseractImage>(imagemVM);
            imagemOCR = _tesseractEngineRepository.ReadImage(imagemOCR);
            imagemVM = _mapper.Map<TesseractImage, ImagemViewModel>(imagemOCR, imagemVM);
            return imagemVM;
        }

        public QrCodeResponseViewModel ObterQrCodeImagem(string text)
        {
            var qrCode = _qrCodeGeneratorRepository.GenerateQrCode(text);
            return _mapper.Map<QrCodeResponseViewModel>(qrCode);
        }
    }
}
