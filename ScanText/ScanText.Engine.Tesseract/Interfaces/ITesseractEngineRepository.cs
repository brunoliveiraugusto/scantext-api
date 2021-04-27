﻿using ScanText.Engine.Tesseract.Models;

namespace ScanText.Engine.Tesseract.Interfaces
{
    public interface ITesseractEngineRepository
    {
        TesseractImage ReadImage(TesseractImage imagem);
        byte[] ConvertBase64ToByteArray(string base64);
        string RemoveLineBreak(string texto);
    }
}