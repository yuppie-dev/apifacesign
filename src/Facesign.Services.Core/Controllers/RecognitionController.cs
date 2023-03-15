using Facesign.Services.Application.Interfaces;
using Facesign.Services.Entities.Facetec;
using Facesign.Services.Entities.Facetec.Request;
using Microsoft.AspNetCore.Mvc;

namespace Facesign.Services.Core.Controllers
{

    //[Route("api/[controller]/[action]")]
  //  [ApiController]
    public class RecognitionController : Controller
    {
        private readonly IExternalServiceApp _externalServiceApp;
        
        public RecognitionController( IExternalServiceApp externalServiceApp)
        {
            _externalServiceApp = externalServiceApp;           
        }

        [HttpGet]
        public ActionResult sessiontoken()
        {
            
            return Ok(_externalServiceApp.sessiontoken(getHeaders()));
        }        


        [HttpPost]
        public ActionResult Create([FromBody] EnrollRequest requestJSON  )
        {    

            return Ok(_externalServiceApp.create(requestJSON, getHeaders()));
        }

        [HttpPost]
        public ActionResult matchid([FromBody] MatchIdRequestModel requestJSON)
        {
            return Ok(_externalServiceApp.matchId(requestJSON, getHeaders()));
        }


        [HttpPost]
        public ActionResult match([FromBody] matchModelRequest requestJSON)
        {

            return Ok(_externalServiceApp.match(requestJSON, getHeaders()));
        }



        private List<FacetecHeaders> getHeaders()
        {
            var list = new List<FacetecHeaders>();

            foreach (var item in Request.Headers.Keys)
            {
                Request.Headers.TryGetValue(item, out var headerValue);

                list.Add(new FacetecHeaders
                {
                    key = item,
                    value = headerValue
                });
            }

            return list;

        }
    }
}
