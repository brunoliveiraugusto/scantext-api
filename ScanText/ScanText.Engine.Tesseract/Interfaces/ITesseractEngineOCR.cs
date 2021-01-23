using System.Threading.Tasks;

namespace ScanText.Engine.Tesseract.Interfaces
{
    public interface ITesseractEngineOCR
    {
        Task<string> ReadImageAsync(string base64);
    }
}
