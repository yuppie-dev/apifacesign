using Facesign.Services.Entities.Client;

namespace Facesign.Services.Domain.Interfaces.Repository
{
    public interface IClientsFunctionalitiesRepository
    {
        Task<ClientsFunctionalitiesModel> GetById(Guid id);

        Task<ClientsFunctionalitiesModel> GetByIdClientId(Guid id_client);

        Task<bool> Create(ClientsFunctionalitiesModel func);

        void Update(ClientsFunctionalitiesModel func);
    }
}
