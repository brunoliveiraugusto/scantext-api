using ScanText.Engine.Tesseract.Interfaces;
using ScanText.Engine.Tesseract.Models;
using System;
using System.IO;
using System.Reflection;
using Tesseract;

namespace ScanText.Engine.Tesseract.Repositories
{
    public class TesseractEngineRepository : ITesseractEngineRepository
    {
        public TesseractImage ReadImage(TesseractImage imagem)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            path = Path.Combine(path, "tessdata").Replace("file:\\", "");

            var bytesImg = ConvertBase64ToByteArray(imagem.Base64);

            try
            {
                using(var engine = new TesseractEngine(path, imagem.SiglaLinguagem, EngineMode.Default))
                {
                    using(var img = Pix.LoadFromMemory(bytesImg))
                    {
                        using(var dataImg = engine.Process(img))
                        {
                            imagem.Texto = dataImg.GetText();
                            imagem.MeanConfidence = dataImg.GetMeanConfidence();
                        }
                    }
                }

                return imagem;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RemoveLineBreak(string texto)
        {
            return texto.Replace("\n", "");
        }

        public byte[] ConvertBase64ToByteArray(string base64)
        {
            var newBase64 = base64.Split(",")[1];
            return Convert.FromBase64String(newBase64);
        }
    }
}
