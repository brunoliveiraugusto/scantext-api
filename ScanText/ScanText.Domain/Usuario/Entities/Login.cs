using System;

namespace ScanText.Domain.Usuario.Entities
{
    public class Login
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string NomeCompleto { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
