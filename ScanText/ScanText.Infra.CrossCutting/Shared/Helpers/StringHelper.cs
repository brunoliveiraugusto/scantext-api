using System;
using System.Text.RegularExpressions;

namespace ScanText.Infra.CrossCutting.Shared.Helpers
{
    public static class StringHelper
    {
        public static byte[] Base64ToArrayByte(string base64)
        {
            string data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64, "");
            return Convert.FromBase64String(data);
        }
    }
}
