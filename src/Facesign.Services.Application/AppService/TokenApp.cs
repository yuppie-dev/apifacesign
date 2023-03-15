using Facesign.Services.Application.Interfaces;
using Facesign.Services.Domain.Interfaces;
using Facesign.Services.Entities.User;

namespace Facesign.Services.Application.AppService
{
    public class TokenApp : ITokenApp
    {
        IToken _token;
        public TokenApp(IToken token)
        {
            _token = token;
        }
        public string Encrypt(string value)
        {
            return _token.Encrypt(value);
        }

        public string Decrypt(string value)
        {
            return _token.Decrypt(value);
        }

        public string TokenGenerator(string chave)
        {
            return _token.TokenGenerator(chave);
        }

        public string DecryptUser(CodingModel coding)
        {
            return _token.DecryptUser(coding);
        }

        public string EncryptUser(CodingModel coding)
        {
            return _token.EncryptUser(coding);
        }
    }
}
