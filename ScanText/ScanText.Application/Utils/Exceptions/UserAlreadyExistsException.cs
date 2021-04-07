using System;

namespace ScanText.Application.Utils.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base("Usuário já cadastrado.")
        {

        }
    }
}
