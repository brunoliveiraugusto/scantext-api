using ScanText.Engine.Models;

namespace ScanText.Engine.Interfaces
{
    public interface IQrCodeGeneratorRepository
    {
        QrCode GenerateQrCode(string text);
    }
}
