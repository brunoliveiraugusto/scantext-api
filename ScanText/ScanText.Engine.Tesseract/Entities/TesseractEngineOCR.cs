using ScanText.Engine.Tesseract.Interfaces;
using System;
using System.IO;
using System.Reflection;
using Tesseract;

namespace ScanText.Engine.Tesseract.Entities
{
    public class TesseractEngineOCR : ITesseractEngineOCR
    {
        public string ReadImage(string base64)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            path = Path.Combine(path, "tessdata").Replace("file:\\", "");

            var texto = string.Empty;
            var bytesImg = ConvertBase64(base64);

            try
            {
                using(var engine = new TesseractEngine(path, "por", EngineMode.Default))
                {
                    using(var img = Pix.LoadFromMemory(bytesImg))
                    {
                        using(var dataImg = engine.Process(img))
                        {
                            texto = dataImg.GetText();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return texto;
        }

        public byte[] ConvertBase64(string base64)
        {
            return Convert.FromBase64String(base64);
        }
    }
}
