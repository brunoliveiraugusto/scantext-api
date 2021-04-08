namespace ScanText.Engine.Tesseract.Services
{
    public class ImagemOCR
    {
        public string Base64 { get; set; }
        public string SiglaLinguagem { get; set; }
        public string Texto { get; set; }
        public float MeanConfidence { get; set; }
    }
}
