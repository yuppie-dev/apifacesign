using Facesign.Services.Entities.SingleSignOn;

namespace Facesign.Services.Domain.Interfaces.Repository
{
    public  interface ISingleSignOnRepository
    {
        void Create(SSOModel sso);
    }
}
