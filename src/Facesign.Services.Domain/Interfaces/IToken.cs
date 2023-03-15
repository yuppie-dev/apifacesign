
using Facesign.Services.Entities.User;

namespace Facesign.Services.Domain.Interfaces
{
    public interface IToken
    {
        string TokenGenerator(string chave);
        string Decrypt(string value);

        string DecryptUser(CodingModel coding);
        string EncryptUser(CodingModel coding);

        string Encrypt(string value);
    }
}
