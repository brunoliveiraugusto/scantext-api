﻿namespace ScanText.Engine.Tesseract.Models
{
    public class TesseractImage
    {
        public string Base64 { get; set; }
        public string SiglaLinguagem { get; set; }
        public string Texto { get; set; }
        public float MeanConfidence { get; set; }
    }
}
