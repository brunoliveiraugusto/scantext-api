using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Security.Encrypt.Interfaces
{
    public interface IEncryptData
    {
        public string Encrypt(string password);
    }
}
