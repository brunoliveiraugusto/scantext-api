using System;
using System.Security.Claims;

namespace ScanText.Security.Authentication.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if(claimsPrincipal == null)
            {
                throw new ArgumentException("Usuário não autenticado.");
            }

            var claim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }
    }
}
