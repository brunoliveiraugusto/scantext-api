using ScanText.Security.Authentication.Interfaces;

namespace ScanText.Security.Authentication.Settings
{
    public class TokenSettings : ITokenSettings
    {
        public string Secret { get; set; }
    }
}
