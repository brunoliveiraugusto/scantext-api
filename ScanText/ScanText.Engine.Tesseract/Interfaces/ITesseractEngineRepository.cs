using ScanText.Engine.Tesseract.Models;

namespace ScanText.Engine.Tesseract.Interfaces
{
    public interface ITesseractEngineRepository
    {
        TesseractImage ReadImage(TesseractImage imagem);
    }
}
