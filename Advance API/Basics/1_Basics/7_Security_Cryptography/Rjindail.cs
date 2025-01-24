using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advance_API._7_Security_Cryptography
{
    public static class Rjindail
    {
        public static void Usage()
        {
            string originalText = "Hello Rijndael!";
            string key = "ThisIsA128BitKey"; // 128-bit key (16 bytes)
            string iv = "ThisIsAnIV123456";  // 128-bit IV (16 bytes)

            // Encrypt the text
            byte[] encrypted = Encrypt(originalText, key, iv);
            Console.WriteLine("Encrypted: " + Convert.ToBase64String(encrypted));

            // Decrypt the text
            string decrypted = Decrypt(encrypted, key, iv);
            Console.WriteLine("Decrypted: " + decrypted);
        }

        public static byte[] Encrypt(string plainText, string key, string iv)
        {
            using (Rijndael rijndael = Rijndael.Create())
            {
                rijndael.Key = Encoding.UTF8.GetBytes(key);
                rijndael.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = rijndael.CreateEncryptor();

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
            using (Rijndael rijndael = Rijndael.Create())
            {
                rijndael.Key = Encoding.UTF8.GetBytes(key);
                rijndael.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = rijndael.CreateDecryptor();

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
