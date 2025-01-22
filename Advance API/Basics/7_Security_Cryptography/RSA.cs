using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advance_API._7_Security_Cryptography
{
    public static class RSA
    {
        // key genration part
        public static Keys KeyGeneration()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))      // Basically create a large number of 2048 bits using 2 lare prime number
            {
                // using the number that RSAService Provider used 

                string publicKey = rsa.ToXmlString(false);  // public key (e,n)
                string privateKey = rsa.ToXmlString(true);  // private key (d,n)

                Console.WriteLine("Public Key: " + publicKey);
                Console.WriteLine("Private Key: " + privateKey);

                return new Keys { PrivateKey = privateKey , PublicKey = publicKey };
            }
        }

        // Encrypt the message using the public key
        public static string Encrypt(string message, string publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(publicKey); // Load the public key into the RSA object

                // Convert the message into a byte array
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(message);

                // Encrypt the data
                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false); // false means no OAEP padding

                // Convert the encrypted byte array to a base64 string to make it easy to display
                return Convert.ToBase64String(encryptedData);
            }
        }

        // Decrypt the message using the private key
        public static string Decrypt(string encryptedMessage, string privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(privateKey); // Load the private key into the RSA object

                // Convert the encrypted message from base64 to byte array
                byte[] dataToDecrypt = Convert.FromBase64String(encryptedMessage);

                // Decrypt the data
                byte[] decryptedData = rsa.Decrypt(dataToDecrypt, false); // false means no OAEP padding

                // Convert the decrypted byte array back to a string
                return Encoding.UTF8.GetString(decryptedData);
            }
        }

        public static void Usage()
        {
            string message = "Hello my name is Meet joshi";

            Keys keyPair = RSA.KeyGeneration();

            string cipher = RSA.Encrypt(message, keyPair.PublicKey);

            string orignal = RSA.Decrypt(cipher, keyPair.PrivateKey);

            Console.WriteLine(cipher);

            Console.WriteLine(orignal);
        }
    }

    public class Keys
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}
