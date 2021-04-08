using System;

namespace ScanText.Engine.Utils.Helper
{
    public static class StringHelper
    {
        public static string ToBase64(this byte[] code)
        {
            return Convert.ToBase64String(code);
        }
    }
}
