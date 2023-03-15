using Facesign.Services.Domain.Interfaces;
using Facesign.Services.Entities.Configuration;
using Facesign.Services.Entities.Facetec;
using Facesign.Services.Entities.Facetec.Request;
using Facesign.Services.Infra.ExternalServices.Request;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facesign.Services.Infra.ExternalServices.Services
{
    public class FacetecExternalService : IExternalService
    {          

        public string sessiontoken(List<FacetecHeaders> list)
        {           
            var result = new HttpRequest().GetToken(BuildConfigurationModel.EndpointSDK,"/session-token", list).Result;

            return result.Content.ReadAsStringAsync().Result;
            
        }               

        public string create(EnrollRequest hash, List<FacetecHeaders> list)
        {

            var result = new HttpRequest().Post(BuildConfigurationModel.EndpointSDK,"/enrollment-3d", list, new StringContent(JsonConvert.SerializeObject(hash))).Result;

            return result.Content.ReadAsStringAsync().Result;
        }

        public string matchId(MatchIdRequestModel hash, List<FacetecHeaders> list)
        {
            var result = new HttpRequest().Post(BuildConfigurationModel.EndpointSDK,"/match-3d-2d-idscan", list, new StringContent(JsonConvert.SerializeObject(hash))).Result;

            return result.Content.ReadAsStringAsync().Result;
        }

        public string match(matchModelRequest hash, List<FacetecHeaders> list)
        {
            var result = new HttpRequest().Post(BuildConfigurationModel.EndpointSDK,"/match-3d-3d", list, new StringContent(JsonConvert.SerializeObject(hash))).Result;

            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
