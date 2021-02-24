using ScanText.Domain.DomainObjects;
using System;

namespace ScanText.Domain.UsuarioDTO.Entities
{
    public class Usuario : Entity<Usuario>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
