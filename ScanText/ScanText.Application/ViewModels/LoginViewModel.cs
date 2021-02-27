using System;

namespace ScanText.Application.ViewModels
{
    public class LoginViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string NomeCompleto { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
