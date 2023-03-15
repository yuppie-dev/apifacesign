using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.Client;
using Facesign.Services.Infra.Data.Data.Client;
using Facesign.Services.Infra.Data.Data.Context;
using Facesign.Services.Infra.Data.Data.Extensions;
using Facesign.Services.Infra.LogService;
using Microsoft.EntityFrameworkCore;

namespace Facesign.Services.Infra.Data.Repository.Client
{
    public class ClientsFunctionalitiesRepository : IClientsFunctionalitiesRepository
    {
        private readonly DbContextOptions<SqlServerContext> _context;

        public ClientsFunctionalitiesRepository(DbContextOptions<SqlServerContext> context, IClientsRepository clientsConfsRepository)
        {
            _context = context;
        }

        public async Task<ClientsFunctionalitiesModel> GetById(Guid id)
        {
            try
            {
                await using var _db = new SqlServerContext(_context);
                var result = await _db.Clients_Functionalities
                       .Where(w => w.id == id)
                       .Select(s => new ClientsFunctionalitiesModel { id = s.id, id_client = s.id_client, match_3d = s.match_3d, liveness_3d = s.liveness_3d, liveness_2d = s.liveness_2d, serpro= s.serpro, url_redirect = s.url_redirect, authenticate_cnh = s.authenticate_cnh, date_insert = s.date_insert, chave = s.chave, sso = s.sso })
                       .FirstOrDefaultWithNoLockAsync();

                return result;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Conf Layout Repository {0}", ex.Message));
                throw;
            }
        }

        public async Task<ClientsFunctionalitiesModel> GetByIdClientId(Guid id_client)
        {
            try
            {
                await using var _db = new SqlServerContext(_context);
                var result = await _db.Clients_Functionalities
                       .Where(w => w.id_client == id_client)
                       .Select(s => new ClientsFunctionalitiesModel { id = s.id, id_client = s.id_client, match_3d = s.match_3d, liveness_3d = s.liveness_3d, liveness_2d = s.liveness_2d, serpro = s.serpro, url_redirect = s.url_redirect, authenticate_cnh = s.authenticate_cnh, date_insert = s.date_insert, chave = s.chave, sso = s.sso })
                       .FirstOrDefaultWithNoLockAsync();

                return result;

            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Conf Layout Repository {0}", ex.Message));
                throw;
            }

        }

        public async Task<bool> Create(ClientsFunctionalitiesModel func)
        {
            try
            {
                var functionality = await GetByIdClientId(func.id_client);
                if (functionality is null)
                {
                    var clientsConfFunctionality = new Clients_FunctionalitiesData()
                    { id_client = func.id_client, match_3d = func.match_3d, liveness_3d = func.liveness_3d, liveness_2d = func.liveness_2d, serpro = func.serpro, url_redirect = func.url_redirect, authenticate_cnh = func.authenticate_cnh, chave = func.chave, sso = func.sso };

                    using var _db = new SqlServerContext(_context);
                    await _db.Clients_Functionalities.AddAsync(clientsConfFunctionality);
                    _db.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Conf Layout Repository {0}", ex.Message));

                return false;
            }
        }

        public void Update(ClientsFunctionalitiesModel func)
        {
            using var _db = new SqlServerContext(_context);

            var dados = _db.Clients_Functionalities.First(x => x.id == func.id);
            dados.sso = func.sso;
            dados.url_redirect = func.url_redirect;
            dados.chave = func.chave;
            dados.serpro = func.serpro;
            dados.liveness_2d   = func.liveness_2d;
            dados.liveness_3d = func.liveness_3d;
            dados.match_3d = func.match_3d;
            dados.authenticate_cnh = func.authenticate_cnh;            

            _db.Update(dados);
            _db.SaveChanges();
        }
    }
}
