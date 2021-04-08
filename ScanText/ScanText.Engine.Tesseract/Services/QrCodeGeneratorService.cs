using QRCoder;
using ScanText.Engine.Interfaces;
using ScanText.Engine.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ScanText.Engine.Services
{
    public class QrCodeGeneratorService : IQrCodeGeneratorService
    {
        public QrCode GenerateQrCode(string text)
        {
            var image = GenerateImage(text);
            return ImageToQrCode(image);
        }

        private Bitmap GenerateImage(string text)
        {
            var qrCodeData = new QRCodeGenerator().CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCodeImage = new QRCode(qrCodeData).GetGraphic(10);
            return qrCodeImage;
        }

        private QrCode ImageToQrCode(Image img)
        {
            using(var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return new QrCode { Code = stream.ToArray() };
            }
        }
    }
}
