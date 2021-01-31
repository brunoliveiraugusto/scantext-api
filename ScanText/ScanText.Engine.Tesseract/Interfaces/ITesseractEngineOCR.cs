namespace ScanText.Engine.Tesseract.Interfaces
{
    public interface ITesseractEngineOCR
    {
        string ReadImage(string base64);
        byte[] ConvertBase64(string base64);
    }
}
