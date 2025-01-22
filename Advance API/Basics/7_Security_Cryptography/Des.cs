using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advance_API._7_Security_Cryptography
{
    public static class Des_Demo
    {
        public static void Usage()
        {
            string originalText = "Hello Meet bhai!";
            string key = "12345678"; // DES requires an 8-byte key
            string iv = "abcdefgh";  // 8-byte Initialization Vector

            // Encrypt the text
            byte[] encrypted = Encrypt(originalText, key, iv);
            Console.WriteLine("Encrypted: " + Convert.ToBase64String(encrypted));

            // Decrypt the text
            string decrypted = Decrypt(encrypted, key, iv);
            Console.WriteLine("Decrypted: " + decrypted);
        }

        public static byte[] Encrypt(string plainText, string key, string iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = des.CreateEncryptor();

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                    sw.Close();
                    return ms.ToArray();
                }
            }
        }

        public static string Decrypt(byte[] cipherText, string key, string iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = des.CreateDecryptor();

                using (MemoryStream ms = new MemoryStream(cipherText))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
