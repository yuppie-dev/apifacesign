using Facesign.Services.Application.Interfaces;
using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.Signature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facesign.Services.Application.AppService
{
    public class SignatureRespositoryApp : ISignatureRepositoryApp
    {
        ISignatureRepository _signatureRepository;

        public SignatureRespositoryApp(ISignatureRepository signatureRepository)
        {
            _signatureRepository = signatureRepository;
        }

        public Guid generatorSignature()
        {
            return _signatureRepository.generatorSignature();
        }

        public SignatureModel GetSignature(Guid id)
        {
            return _signatureRepository.GetSignature(id);
        }

        public Task<SignatureModel> GetSignatureByCpf(string cpf)
        {
            return _signatureRepository.GetSignatureByCpf(cpf);
        }

        public void saveSignature(SignatureModel signature)
        {
            _signatureRepository.saveSignature(signature);
        }

        public bool validatorSignature(Guid chave)
        {
            return _signatureRepository.validatorSignature(chave);
        }
    }
}
