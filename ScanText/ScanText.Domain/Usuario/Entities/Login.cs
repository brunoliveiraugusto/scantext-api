using ScanText.Domain.EntityDomain;
using System;

namespace ScanText.Domain.Usuario.Entities
{
    public class Login : Entity<Login>
    {
        public string Username { get; set; }
        public string NomeCompleto { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }

        public override void IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
