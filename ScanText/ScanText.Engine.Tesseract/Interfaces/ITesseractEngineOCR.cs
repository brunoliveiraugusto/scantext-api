namespace ScanText.Engine.Tesseract.Interfaces
{
    public interface ITesseractEngineOCR
    {
        string ReadImage(string base64);
        byte[] ConvertBase64ToByteArray(string base64);
        string RemoveLineBreak(string texto);
    }
}
