using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Domain.UsuarioDTO.Entities
{
    public class Login
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
