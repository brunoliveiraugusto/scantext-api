using ScanText.Application.ViewModels;

namespace ScanText.Application.Interfaces
{
    public interface IScanAppService
    {
        ImagemViewModel LerTextoImagem(ImagemViewModel imagemVM);
        QrCodeResponseViewModel ObterQrCodeImagem(string text);
    }
}
