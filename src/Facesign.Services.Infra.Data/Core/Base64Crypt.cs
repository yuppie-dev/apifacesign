using System.Text;

namespace Facesign.Services.Infra.Data.Core
{
    public class Base64Crypt
    {
        public Encoding Encode
        {
            get;
            private set;
        }

        public Base64Crypt() : this(Encoding.Default) { }
        public Base64Crypt(Encoding encoding)
        {
            this.Encode = encoding;
        }

        public string Encrypt(string text)
        {
            byte[] bytes = Encode.GetBytes(text);

            return Convert.ToBase64String(bytes);
        }

        public string Decrypt(string text)
        {
            byte[] bytes = Convert.FromBase64String(text);
           
            var result = Encode.GetString(bytes);

            return result;
        }
    }
}
