using System;

namespace ScanText.Security.Authentication.Interfaces
{
    public interface IUsuarioService
    {
        Guid GetUserId();
        bool IsAuthenticated();
    }
}
