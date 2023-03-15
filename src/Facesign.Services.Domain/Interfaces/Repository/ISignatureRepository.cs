using Facesign.Services.Entities.Signature;

namespace Facesign.Services.Domain.Interfaces.Repository
{
    public interface ISignatureRepository
    {
        SignatureModel GetSignature(Guid id);
        Task<SignatureModel> GetSignatureByCpf(string cpf);
        bool validatorSignature(Guid chave);       

        Guid generatorSignature();

        void saveSignature(SignatureModel signature);
    }
}
