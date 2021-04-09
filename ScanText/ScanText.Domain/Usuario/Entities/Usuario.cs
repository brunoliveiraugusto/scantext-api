using ScanText.Domain.EntityDomain;
using System;

namespace ScanText.Domain.Usuario.Entities
{
    public class Usuario : Entity<Usuario>
    {
        public string Username { get; set; }
        public string NomeCompleto { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Role { get; set; }
    }
}
