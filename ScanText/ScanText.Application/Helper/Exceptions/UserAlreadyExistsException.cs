using System;

namespace ScanText.Application.Helper.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base("Usuário já cadastrado.")
        {

        }
    }
}
