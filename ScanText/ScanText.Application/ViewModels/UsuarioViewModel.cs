using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
