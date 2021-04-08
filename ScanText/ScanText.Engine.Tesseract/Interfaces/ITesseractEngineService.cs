using ScanText.Engine.Tesseract.Models;

namespace ScanText.Engine.Tesseract.Interfaces
{
    public interface ITesseractEngineService
    {
        ImagemOCR ReadImage(ImagemOCR imagem);
        byte[] ConvertBase64ToByteArray(string base64);
        string RemoveLineBreak(string texto);
    }
}
