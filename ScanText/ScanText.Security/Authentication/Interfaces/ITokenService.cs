using ScanText.Security.Authentication.Entities;
using System.Security.Principal;

namespace ScanText.Security.Authentication.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioAuthentication usuario);
        string GenerateSimpleToken();
        void SetIdentityUser(IIdentity identity, string[] roles);
    }
}
