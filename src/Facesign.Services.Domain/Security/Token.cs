using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Facesign.Services.Domain.Interfaces;
using Facesign.Services.Entities.User;

namespace Facesign.Services.Domain.Security
{
    public class Token : IToken
    {
        internal const int Keysize = 256;
        internal const int DerivationIterations = 1000;

        public string TokenGenerator(string chave)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret.GetSecret());
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, chave));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string Encrypt(string value)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(value);

            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(Secret.GetSecret(), new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        value = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return value;
        }

        public string Decrypt(string value)
        {
            value = value.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(value);
            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(Secret.GetSecret(), new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        value = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return value;
        }

        public string DecryptUser(CodingModel code)
        {
            code.value = code.value.Replace(" ", "+");
            byte[] bytesToBeDecrypted = Convert.FromBase64String(code.value);

            byte[] passwordBytesdecrypt = Encoding.UTF8.GetBytes(string.IsNullOrEmpty(code.chave) ? Secret.GetSecret() : code.chave);
            passwordBytesdecrypt = SHA512.Create().ComputeHash(passwordBytesdecrypt);



            // byte[] saltBytes = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

            byte[] saltBytes = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64 };

           // byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytesdecrypt, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                  code.value=  Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            return code.value;
        }    

        public string EncryptUser(CodingModel code)
        {

            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(code.value);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(string.IsNullOrEmpty(code.chave) ? Secret.GetSecret() : code.chave);           
            
            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);


            // byte[] saltBytes = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
            byte[] saltBytes = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64 };
            //byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (var AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    code.value = Convert.ToBase64String(ms.ToArray());                    
                }
            }            

            return code.value;

        }        
      
    }
    


    public class Secret
    {
        private const string _value = "173a645090ae60948301e1c44fea7461";
        public static string GetSecret()
        {
            return "F@se51gn";
            try
            {
                string[] splitter = new string[] { "0a" };
                var splitted = _value.Split(splitter, StringSplitOptions.None);
                var value = $"{GetTickets()}{splitted[1].Substring(3, 3)}{splitted[0].Substring(3, 3)}" +
                    $"0a{splitted[1].Substring(18, 3)}{splitted[0].Substring(0, 3)}{splitted[1].Substring(0, 3)}" +
                    $"0a{splitted[1].Substring(15, 3)}{splitted[1].Substring(6, 3)}{GetTickets()}" +
                    $"0a{splitted[1].Substring(12, 3)}{splitted[1].Substring(9, 3)}" +
                    $"0a{splitted[0].Substring(6, 3)}{GetTickets()}";

                var bTxt = Encoding.Default.GetBytes(value.Substring(0,10));

                return Convert.ToBase64String(bTxt);

            }
            catch (Exception)
            {
                return null;
            }
        }
        private static string GetTickets()
        {
            DateTime centBegin = new DateTime(2001, 1, 1);
            DateTime current = new DateTime(2002, 11, 25);

            var elapseT = current.Subtract(centBegin).Days;

            var tH = elapseT.ToString("X");

            tH = tH.Replace("0a", "1A");

            return tH.ToLower();
        }
    }
}
