using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Domain.Usuario.Helper
{
    public class UsuarioHelper
    {
        public static string AplicarMascaraEmail(string email)
        {
            char[] caracteresEmail = email.ToCharArray();
            string emailComMascara = string.Empty;
            bool dominio = false;

            for (int i = 0; i < caracteresEmail.Length; i++)
            {
                if (caracteresEmail[i] == '@')
                    dominio = true;

                if (i == 0 || i == 1 || i == caracteresEmail.Length - 1 || i == caracteresEmail.Length - 2 || i == caracteresEmail.Length - 3 || dominio)
                {
                    emailComMascara += caracteresEmail[i];
                }
                else
                {
                    emailComMascara += "*";
                }
            }

            return emailComMascara;
        }
    }
}
