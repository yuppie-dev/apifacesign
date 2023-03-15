using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.Client;
using Facesign.Services.Infra.Data.Data.Client;
using Facesign.Services.Infra.Data.Data.Context;
using Facesign.Services.Infra.Data.Data.Extensions;

using Facesign.Services.Infra.LogService;
using Microsoft.EntityFrameworkCore;

namespace Facesign.Services.Infra.Data.Repository.Client
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly DbContextOptions<SqlServerContext> _context;   

        public ClientsRepository(DbContextOptions<SqlServerContext> context)
        {
            _context = context;        
        }

        public async Task<ClientsModel> Get(string cpf)
        {
            try
            {
                await using var _db = new SqlServerContext(_context);
                var result = await _db.Clients.Where(w => w.cpf == cpf)
                    .Select(s => new ClientsModel { id = s.id, name = s.name, cpf = s.cpf, telephone = s.telephone, date_insert = s.date_insert, validate= s.validate, status=s.status })
                    .FirstOrDefaultWithNoLockAsync();
                return result;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Repository {0}", ex.Message));

                throw;
            }
        }

        public async Task<ClientsModel> Get(Guid id)
        {
            try
            {
                await using var _db = new SqlServerContext(_context);
                var result = await _db.Clients.Where(w => w.id == id)
                    .Select(s => new ClientsModel { id = s.id, name = s.name, cpf = s.cpf, telephone = s.telephone, date_insert = s.date_insert, status = s.status })
                    .FirstOrDefaultWithNoLockAsync();
          

                return result;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Repository {0}", ex.Message));

                throw;
            }
        }

        public async Task<List<ClientSummaryModel>> Get()
        {
            try
            {
                await using var _db = new SqlServerContext(_context);

                var result = await _db.Clients
                    .Select(s => new ClientSummaryModel { id = s.id, name = s.name, document = s.cpf, telephone = s.telephone, date_insert = s.date_insert})
                    .ToListWithNoLockAsync();
                return result;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Repository {0}", ex.Message));

                throw;
            }
        }

        Guid IClientsRepository.Create(ClientsModel client)
        {
            try
            {
                ClientsData clientsData = new ClientsData()
                { status=0, cpf = client.cpf.Trim().Replace(" ",""), name = client.name, telephone = client.telephone };

                using var _db = new SqlServerContext(_context);
                _db.Clients.Add(clientsData);
                _db.SaveChanges();

                return clientsData.id;

            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Repository {0}", ex.Message));

                return Guid.Empty;
            }
        }

        bool IClientsRepository.Validator(Guid chave)
        {
            using var _db = new SqlServerContext(_context);
            var result = _db.Clients.Where(w => w.id == chave && w.status == 0).FirstOrDefault();

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

        public void Update(ClientsModel client)
        {
            using var _db = new SqlServerContext(_context);

            var dados = _db.Clients.First(x => x.id == client.id);

            dados.name = client.name;
            dados.telephone = client.telephone;
            dados.status = client.status;
            dados.validate = client.validate;
            dados.status = client.status;

            _db.Update(dados);
            _db.SaveChanges();
        }       
    }
}
