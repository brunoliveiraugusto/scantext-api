using ScanText.Engine.Tesseract.Entities;

namespace ScanText.Engine.Tesseract.Interfaces
{
    public interface ITesseractEngineOCR
    {
        ImagemOCR ReadImage(ImagemOCR imagem);
        byte[] ConvertBase64ToByteArray(string base64);
        string RemoveLineBreak(string texto);
    }
}
