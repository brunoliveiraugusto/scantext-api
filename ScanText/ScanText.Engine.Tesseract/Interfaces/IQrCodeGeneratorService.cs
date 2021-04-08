using ScanText.Engine.Models;

namespace ScanText.Engine.Interfaces
{
    public interface IQrCodeGeneratorService
    {
        QrCode GenerateQrCode(string text);
    }
}
