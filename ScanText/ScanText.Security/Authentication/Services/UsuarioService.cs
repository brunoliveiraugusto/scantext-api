using Microsoft.AspNetCore.Http;
using ScanText.Security.Authentication.Extensions;
using ScanText.Security.Authentication.Interfaces;
using System;

namespace ScanText.Security.Authentication.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IHttpContextAccessor _acessor;

        public UsuarioService(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_acessor.HttpContext.User.GetUserId()) : throw new ArgumentException("Usuário não autenticado.");
        }

        public bool IsAuthenticated()
        {
            return _acessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
