using ScanText.Engine.Tesseract.Models;

namespace ScanText.Test.ApplicationTest.Builders.Domain
{
    public class TesseractImageTestBuilder : BaseTestBuilder<TesseractImage>
    {
        public TesseractImageTestBuilder()
        {
            Model = new TesseractImage();
        }

        public TesseractImageTestBuilder Default()
        {
            Model.Base64 = "base64,hfaksjdhfaksdhfakshdf";
            Model.MeanConfidence = 90.0f;
            Model.SiglaLinguagem = "por";
            Model.Texto = "Texto da imagem.";

            return this;
        }
    }
}
