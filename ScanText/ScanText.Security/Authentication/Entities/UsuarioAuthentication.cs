using System;

namespace ScanText.Security.Authentication.Entities
{
    public class UsuarioAuthentication
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
