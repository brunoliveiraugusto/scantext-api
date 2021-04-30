using ScanText.Engine.Tesseract.Interfaces;
using ScanText.Engine.Tesseract.Models;
using ScanText.Engine.Utils.Helper;
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
            string path = GetDirectoryName();
            byte[] bytesImg = StringHelper.ConvertBase64ToByteArray(imagem.Base64);

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

        private string GetDirectoryName()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            return Path.Combine(path, "tessdata").Replace("file:\\", "");
        }
    }
}
