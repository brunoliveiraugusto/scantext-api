using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Engine.Tesseract.Models;
using ScanText.Engine.Tesseract.Interfaces;

namespace ScanText.Application.Services
{
    public class ScanAppService : IScanAppService
    {
        private readonly ITesseractEngineService _tesseractEngineOCR;
        private readonly IMapper _mapper;

        public ScanAppService(ITesseractEngineService tesseractEngineOCR, IMapper mapper)
        {
            _tesseractEngineOCR = tesseractEngineOCR;
            _mapper = mapper;
        }

        public ImagemViewModel LerTextoImagem(ImagemViewModel imagemVM)
        {
            var imagemOCR = _mapper.Map<TesseractImage>(imagemVM);
            imagemOCR = _tesseractEngineOCR.ReadImage(imagemOCR);
            imagemVM = _mapper.Map<TesseractImage, ImagemViewModel>(imagemOCR, imagemVM);
            return imagemVM;
        }
    }
}
