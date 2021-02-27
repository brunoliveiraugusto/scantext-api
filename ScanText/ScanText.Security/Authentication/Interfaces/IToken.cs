using ScanText.Security.Authentication.Entities;

namespace ScanText.Security.Authentication.Interfaces
{
    public interface IToken
    {
        string GenerateToken(UsuarioAuthentication usuario);
    }
}
