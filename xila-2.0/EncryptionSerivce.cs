using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace xila_2._0
{
    internal class EncryptionSerivce
    {
        public void EncryptFile(string filePath, string symmetricKey)
        {
            try
            {
                byte[] plainText = File.ReadAllBytes(filePath);
                using (var DES = new DESCryptoServiceProvider())
                {
                    DES.IV = Encoding.UTF8.GetBytes(symmetricKey);
                    DES.Key = Encoding.UTF8.GetBytes(symmetricKey);
                    DES.Mode = CipherMode.CBC;
                    DES.Padding = PaddingMode.PKCS7;

                    using (var memStream = new MemoryStream())
                    {
                        CryptoStream stream = new CryptoStream(memStream, DES.CreateEncryptor(), CryptoStreamMode.Write);
                        stream.Write(plainText, 0, plainText.Length);
                        stream.FlushFinalBlock();
                        File.WriteAllBytes(filePath, memStream.ToArray());
                    }
                }
            }
            catch { }
        }

        public void DecryptFile(string filePath, string symmetricKey)
        {
            try
            {
                byte[] encryptedText = File.ReadAllBytes(filePath);
                using (var DES = new DESCryptoServiceProvider())
                {
                    DES.IV = Encoding.UTF8.GetBytes(symmetricKey);
                    DES.Key = Encoding.UTF8.GetBytes(symmetricKey);
                    DES.Mode = CipherMode.CBC;
                    DES.Padding = PaddingMode.PKCS7;

                    using (var memStream = new MemoryStream())
                    {
                        CryptoStream stream = new CryptoStream(memStream, DES.CreateDecryptor(), CryptoStreamMode.Write);
                        stream.Write(encryptedText, 0, encryptedText.Length);
                        stream.FlushFinalBlock();
                        File.WriteAllBytes(filePath, memStream.ToArray());
                    }
                }
            }
            catch { }
        }

    }
}
