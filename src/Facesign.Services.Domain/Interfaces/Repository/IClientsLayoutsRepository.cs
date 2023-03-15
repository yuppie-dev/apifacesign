using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facesign.Services.Entities.Client;

namespace Facesign.Services.Domain.Interfaces.Repository
{
    public interface IClientsLayoutsRepository
    {
        Task<ClientsLayoutsModel> GetByIdAsync(Guid id);

        Task<ClientsLayoutsModel> GetByIdClientId(Guid id);

        Task<Guid> Create(ClientsLayoutsModel layout);

        void Update(ClientsLayoutsModel layout);

    }
}
