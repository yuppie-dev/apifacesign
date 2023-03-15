using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.Client;
using Facesign.Services.Infra.Data.Data.Client;
using Facesign.Services.Infra.Data.Data.Context;
using Facesign.Services.Infra.Data.Data.Extensions;
using Facesign.Services.Infra.LogService;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Facesign.Services.Infra.Data.Repository.Client
{
    public class ClientsLayoutsRepository : IClientsLayoutsRepository
    {
        private readonly DbContextOptions<SqlServerContext> _context;

        public ClientsLayoutsRepository(DbContextOptions<SqlServerContext> context)
        {
            _context = context;
        }

        public async Task<ClientsLayoutsModel> GetByIdAsync(Guid id)
        {
            try
            {
                await using var _db = new SqlServerContext(_context);
                var result = await _db.Clients_Layouts
                       .Where(w => w.id == id)
                       .Select(s => new ClientsLayoutsModel { id_client = s.id_client, home_image = Convert.ToBase64String(s.home_image), icon = Convert.ToBase64String(s.icon), primary_color = s.primary_color, secundary_color = s.secundary_color, date_insert = s.date_insert })
                       .FirstOrDefaultWithNoLockAsync();

                return result;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Conf Layout Repository {0}", ex.Message));
                throw;
            }
        }

        public async Task<ClientsLayoutsModel> GetByIdClientId(Guid id)
        {
            try
            {
                await using var _db = new SqlServerContext(_context);
                var result = await _db.Clients_Layouts
                       .Where(w => w.id_client == id)
                       .Select(s => new ClientsLayoutsModel { id= s.id, id_client = s.id_client, home_image = Convert.ToBase64String(s.home_image), icon = Convert.ToBase64String(s.icon), primary_color = s.primary_color, secundary_color = s.secundary_color, date_insert = s.date_insert })
                       .FirstOrDefaultWithNoLockAsync();

                return result;

            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Conf Layout Repository {0}", ex.Message));
                throw;
            }

        }

        public void Update(ClientsLayoutsModel layout)
        {
            using var _db = new SqlServerContext(_context);

            var dados = _db.Clients_Layouts.First(x => x.id == layout.id);
            dados.primary_color = layout.primary_color;
            dados.secundary_color = layout.secundary_color;
            dados.home_image = Convert.FromBase64String(layout.home_image);
            dados.icon = Convert.FromBase64String(layout.icon);

            _db.Update(dados);
            _db.SaveChanges();
        }

        async Task<Guid> IClientsLayoutsRepository.Create(ClientsLayoutsModel layout)
        {
            try
            {
                var layoutConf = await GetByIdClientId(layout.id_client);
                if (layoutConf is null)
                {
                    var clientsConfLayoutData = new Clients_LayoutsData()
                    { id_client = layout.id_client, home_image = Convert.FromBase64String(layout.home_image), icon = Convert.FromBase64String(layout.icon), primary_color = layout.primary_color, secundary_color = layout.secundary_color };

                    using var _db = new SqlServerContext(_context);
                    await _db.Clients_Layouts.AddAsync(clientsConfLayoutData);
                    _db.SaveChanges();

                    return clientsConfLayoutData.id;
                }
                else
                    return Guid.Empty;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Conf Layout Repository {0}", ex.Message));

                return Guid.Empty;
            }
        }
    }
}
