using ServiceStack;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FinalDemo.Security
{
    public static class Rjindial_Crypto_Service
    {
        private readonly static string key = "ThisIsA128BitKey"; // 128-bit key (16 bytes)
        private readonly static string iv = "ThisIsAnIV123456";  // 128-bit IV (16 bytes)

        public static void Usage()
        {
            string originalText = "Hello Rijndael!";

            // Encrypt the text
            string encrypted = Encrypt(originalText);
            Console.WriteLine("Encrypted: " + encrypted);

            // Decrypt the text
            string decrypted = Decrypt(encrypted); // Use Convert.FromBase64String instead
            Console.WriteLine("Decrypted: " + decrypted);
        }

        public static string Encrypt(string plainText)
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
                    return Convert.ToBase64String(ms.ToArray()); // Return the Base64 encoded ciphertext
                }
            }
        }

        public static string Decrypt(string ctxt)
        {
            using (Rijndael rijndael = Rijndael.Create())
            {
                Byte[] cipherText = Convert.FromBase64String(ctxt);
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
