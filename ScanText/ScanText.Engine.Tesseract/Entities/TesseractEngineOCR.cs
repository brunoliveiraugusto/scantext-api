using ScanText.Engine.Tesseract.Interfaces;
using System.Threading.Tasks;

namespace ScanText.Engine.Tesseract.Entities
{
    public class TesseractEngineOCR : ITesseractEngineOCR
    {
        public async Task<string> ReadImageAsync(string base64)
        {
            throw new System.NotImplementedException();
        }
    }
}
