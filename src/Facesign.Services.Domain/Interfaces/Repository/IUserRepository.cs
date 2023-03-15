using Facesign.Services.Entities.User;
using Facesign.Services.Entities.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facesign.Services.Domain.Interfaces.Repository
{
    public interface IUserRepository 
    {
        Task<UserModel> Get(string cpf);
        Task<UserModel> Get(Guid id);
        Task<List<UserModel>> Get();
        Guid Create(UserModel user);
        void Update(UserModel user);

        Task<bool> CPFVerify(ValueVerifyModel check);

    }
}
