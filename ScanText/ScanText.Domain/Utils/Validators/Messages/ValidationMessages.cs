using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Domain.Utils.Validators.Messages
{
    public static class ValidationMessages
    {
        public static string CampoObrigatorio(string name) 
        { 
            return $"O preenchimento do campo {name} é obrigatório.";
        }
    }
}
