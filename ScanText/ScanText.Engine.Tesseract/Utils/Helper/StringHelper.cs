using System;

namespace ScanText.Engine.Utils.Helper
{
    public static class StringHelper
    {
        public static string ToBase64(this byte[] code)
        {
            return Convert.ToBase64String(code);
        }

        public static string RemoveLineBreak(string texto)
        {
            return texto.Replace("\n", "");
        }

        public static byte[] ConvertBase64ToByteArray(string base64)
        {
            var newBase64 = base64.Split(",")[1];
            return Convert.FromBase64String(newBase64);
        }
    }
}
