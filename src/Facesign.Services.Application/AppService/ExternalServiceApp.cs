

using Facesign.Services.Application.Interfaces;
using Facesign.Services.Domain.Interfaces;
using Facesign.Services.Entities.Facetec;
using Facesign.Services.Entities.Facetec.Request;
using Microsoft.AspNetCore.Http;

namespace Facesign.Services.Application.AppService
{
    public  class ExternalServiceApp : IExternalServiceApp
    {
        IExternalService _externalService;
        public ExternalServiceApp(IExternalService externalService)
        {
            _externalService = externalService;
        }                  

        public string sessiontoken(List<FacetecHeaders> list)
        {
            return _externalService.sessiontoken(list);
        }

        public string create(EnrollRequest hash, List<FacetecHeaders> list)
        {
            return _externalService.create(hash, list);
        }

        public string matchId(MatchIdRequestModel hash, List<FacetecHeaders> list)
        {
            return _externalService.matchId(hash, list);
        }

        public string match(matchModelRequest hash, List<FacetecHeaders> list)
        {
            return _externalService.match(hash, list);
        }
    }
}
