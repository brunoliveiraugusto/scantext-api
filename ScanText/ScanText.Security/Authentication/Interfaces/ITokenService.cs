using ScanText.Security.Authentication.Entities;

namespace ScanText.Security.Authentication.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioAuthentication usuario);
    }
}
