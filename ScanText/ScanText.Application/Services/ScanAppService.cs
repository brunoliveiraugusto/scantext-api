using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Engine.Tesseract.Services;
using ScanText.Engine.Tesseract.Interfaces;

namespace ScanText.Application.Services
{
    public class ScanAppService : IScanAppService
    {
        private readonly ITesseractEngineOCR _tesseractEngineOCR;
        private readonly IMapper _mapper;

        public ScanAppService(ITesseractEngineOCR tesseractEngineOCR, IMapper mapper)
        {
            _tesseractEngineOCR = tesseractEngineOCR;
            _mapper = mapper;
        }

        public ImagemViewModel LerTextoImagem(ImagemViewModel imagemVM)
        {
            var imagemOCR = _mapper.Map<ImagemOCR>(imagemVM);
            imagemOCR = _tesseractEngineOCR.ReadImage(imagemOCR);
            imagemVM = _mapper.Map<ImagemOCR, ImagemViewModel>(imagemOCR, imagemVM);
            return imagemVM;
        }
    }
}
