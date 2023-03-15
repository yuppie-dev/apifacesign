
using Facesign.Services.Entities.Facetec;
using Facesign.Services.Entities.Facetec.Request;
using Microsoft.AspNetCore.Http;

namespace Facesign.Services.Domain.Interfaces
{
    public interface IExternalService
    {

        string sessiontoken(List<FacetecHeaders> list);

        string create(EnrollRequest hash, List<FacetecHeaders> list);

        string matchId(MatchIdRequestModel hash, List<FacetecHeaders> list);

        string match(matchModelRequest hash, List<FacetecHeaders> list);
    }
}
