using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Core.Utilities.Security.Hash.MD5
{
    public class MD5HashService : IMD5Service
    {
        string hash = "ASPDOTNETMVC09032023";

        /// <summary>
        /// Metni MD% dönüştürür
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ConvertTextToMD5(string text)
        {
            MD5CryptoServiceProvider pwd = new MD5CryptoServiceProvider();
            return EncryptionToMD5(text, pwd);
        }

        private string EncryptionToMD5(string text, HashAlgorithm algorithm)
        {
            byte[] byteValue = Encoding.UTF8.GetBytes(text);
            byte[] encryptByte = algorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(encryptByte);
        }

        public string Decrypt(string encryptValue)
        {
            byte[] data = Convert.FromBase64String(encryptValue);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
                {
                    Key = keys,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.UTF8.GetString(results);
                }
            }
        }

        public string Encrypt(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(result, 0, result.Length);
                }
            }
        }
    }
}
