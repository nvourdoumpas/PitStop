using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PitStop.Core.Helpers
{
    public class Util
    {
        #region public static string Encrypt(string? plainText)
        public static string Encrypt(string? plainText)
        {
            if (String.IsNullOrEmpty(plainText)) throw new ArgumentNullException(nameof(plainText));

            string key = "P1tSt0PS3cet!";
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32)); // 256-bit key
            aes.GenerateIV();

            using var encryptor = aes.CreateEncryptor();
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            var result = Convert.ToBase64String(aes.IV.Concat(cipherBytes).ToArray());
            return result;
        }
        #endregion
        #region public static string Decrypt(string? encryptedText)
        public static string Decrypt(string? encryptedText)
        {
            if (String.IsNullOrEmpty(encryptedText)) throw new ArgumentNullException(nameof(encryptedText));

            string key = "P1tSt0PS3cet!";
            var fullCipher = Convert.FromBase64String(encryptedText);
            var iv = fullCipher.Take(16).ToArray();
            var cipherText = fullCipher.Skip(16).ToArray();

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            var decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        #endregion
    }
}
