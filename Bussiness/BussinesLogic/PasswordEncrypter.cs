using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Bussiness.BussinesLogic
{
    public class PasswordEncrypter
    {
        public static string Compute256Hash(string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}
