using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ATAarhitektonskiStudio.Helpers
{
    public class PasswordHashing
    {
        public static string GenerateSalt()
        {
            byte[] arr = new byte[16];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(arr);
            return Convert.ToBase64String(arr);
        }
        public static string GenerateHash(string password, string salt)
        {
            byte[] pass = Encoding.Unicode.GetBytes(password);
            byte[] addOn = Convert.FromBase64String(salt);
            byte[] forHash = new byte[pass.Length + addOn.Length];

            System.Buffer.BlockCopy(pass, 0, forHash, 0, pass.Length);
            System.Buffer.BlockCopy(addOn, 0, forHash, pass.Length, addOn.Length);

            HashAlgorithm alg = HashAlgorithm.Create("SHA1");
            byte[] hashed = alg.ComputeHash(forHash);
            return Convert.ToBase64String(hashed);
        }
    }
}