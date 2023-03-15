using Facesign.Services.Entities.Client;

namespace Facesign.Services.Domain.Interfaces.Repository
{
    public interface IClientsRepository
    {
        bool Validator(Guid chave);

        Task<ClientsModel> Get(string cpf);
        Task<ClientsModel> Get(Guid id);
        Task<List<ClientSummaryModel>> Get();

       Guid Create(ClientsModel client);

        void Update(ClientsModel client);   

    }
}
