using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Engine.Tesseract.Models;
using ScanText.Engine.Tesseract.Interfaces;
using ScanText.Engine.Interfaces;
using ScanText.Engine.Models;

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

        public ImagemTesseractResponseViewModel LerTextoImagem(ImagemTesseractViewModel imagemVM)
        {
            var imagemOCR = ConvertModelMapper<TesseractImage, ImagemTesseractViewModel>(imagemVM);
            imagemOCR = _tesseractEngineRepository.ReadImage(imagemOCR);
            return ConvertModelMapper<ImagemTesseractResponseViewModel, TesseractImage>(imagemOCR);
        }

        public QrCodeResponseViewModel GerarQrCodeImagem(string text)
        {
            var qrCode = _qrCodeGeneratorRepository.GenerateQrCode(text);
            return ConvertModelMapper<QrCodeResponseViewModel, QrCode>(qrCode);
        }

        public T ConvertModelMapper<T, M>(M model)
            where T : class
            where M : class
        {
            return _mapper.Map<T>(model);
        }
    }
}
