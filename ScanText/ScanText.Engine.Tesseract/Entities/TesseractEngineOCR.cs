using ScanText.Engine.Tesseract.Interfaces;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Tesseract;

namespace ScanText.Engine.Tesseract.Entities
{
    public class TesseractEngineOCR : ITesseractEngineOCR
    {
        public string ReadImage(string urlImg)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            path = Path.Combine(path, "tessdata").Replace("file:\\", "");

            var texto = string.Empty;

            try
            {
                using(var engine = new TesseractEngine(path, "por", EngineMode.Default))
                {
                    using(var img = Pix.LoadFromFile(urlImg))
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
    }
}
