using ScanText.Application.ViewModels;

namespace ScanText.Application.Interfaces
{
    public interface IScanAppService
    {
        ImagemTesseractResponseViewModel LerTextoImagem(ImagemTesseractViewModel imagemVM);
        QrCodeResponseViewModel GerarQrCodeImagem(string text);
    }
}
