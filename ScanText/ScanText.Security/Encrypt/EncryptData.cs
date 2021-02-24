using ScanText.Security.Encrypt.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ScanText.Security.Encrypt
{
    public class EncryptData : IEncryptData
    {
        public string Encrypt(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            string hash = Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
