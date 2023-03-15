using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.Signature;
using Facesign.Services.Infra.Data.Data.Context;
using Facesign.Services.Infra.Data.Data.Signature;
using Facesign.Services.Infra.Data.Repository.Client;
using Facesign.Services.Infra.LogService;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Facesign.Services.Infra.Data.Repository.Signature
{
    public class SignatureRepository : ISignatureRepository
    {
        private readonly DbContextOptions<SqlServerContext> _context;

        public SignatureRepository(DbContextOptions<SqlServerContext> context)
        {
            _context = context;
        }

        public Guid generatorSignature()
        {
            try
            {
                SignaturesData data = new SignaturesData()
                { status = 0, validate = DateTime.Now.AddDays(1) };

                using var _db = new SqlServerContext(_context);
                _db.Signatures.Add(data);
                _db.SaveChanges();
                return data.id;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Signature Repository {0}", ex.Message));
                throw;
            }


        }

        public SignatureModel GetSignature(Guid id)
        {
            try
            {
                using var _db = new SqlServerContext(_context);               

                var result = _db.Signatures.FirstOrDefault(c => c.id == id);

                if (result == null)
                    return new SignatureModel();

                var signature = new SignatureModel
                {
                    id = result.id,                    
                    image = result.image,
                    cpf = result.cpf,
                    ip = result.ip,
                    deviceModel = result.deviceModel,
                    matchLevel = (int)result.matchLevel
                };

                return signature;

            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Signature Repository {0}", ex.Message));
                throw;
            }
        }

        public async Task<SignatureModel> GetSignatureByCpf(string cpf)
        {
            try
            {
                using var _db = new SqlServerContext(_context);

                var result = _db.Signatures.OrderByDescending(x => x.date_insert).FirstOrDefault(c => c.cpf == cpf);

                if (result == null)
                    return null;

                var signature = new SignatureModel
                {
                    id = result.id,
                    image = result?.image,
                    cpf = result?.cpf,
                    ip = result?.ip,
                    deviceModel = result?.deviceModel,
                    matchLevel = (int)result?.matchLevel
                };

                return signature;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Signature Repository {0}", ex.Message));
                throw;
            }
        }

        public void saveSignature(SignatureModel signature)
        {
            try
            {
                using var _db = new SqlServerContext(_context);
                var result = _db.Signatures.Where(w => w.id == signature.id).FirstOrDefault();

                result.status = 1;
                result.dataSignature = DateTime.Now;
                result.cpf = signature.cpf;
                result.image = signature.image;
                result.matchLevel = signature.matchLevel;
                result.ip = signature.ip;
                result.deviceModel = signature.deviceModel;
                result.location = signature.location;
                _db.Update(result);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Signature Repository {0}", ex.Message));
                throw;
            }



        }

        bool ISignatureRepository.validatorSignature(Guid chave)
        {
            try
            {
                using var _db = new SqlServerContext(_context);
                var result = _db.Signatures.Where(w => w.id == chave && w.status == 0).FirstOrDefault();


                if (result == null)
                    return false;
                else
                {
                    var tempob = Convert.ToDateTime(result.validate).Subtract(DateTime.Now).TotalSeconds;

                    if (tempob > 0)
                        return true;
                    else
                        return false;
                }


            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Signature Repository {0}", ex.Message));
                return false;
            }
        }

    }
}
