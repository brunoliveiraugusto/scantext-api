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

            var text = string.Empty;
            var bytesImg = ConvertBase64ToByteArray(base64);

            try
            {
                using(var engine = new TesseractEngine(path, "por", EngineMode.Default))
                {
                    using(var img = Pix.LoadFromMemory(bytesImg))
                    {
                        using(var dataImg = engine.Process(img))
                        {
                            text = dataImg.GetText();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RemoveLineBreak(text);
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
