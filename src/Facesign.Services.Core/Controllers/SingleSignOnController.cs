using Facesign.Services.Application.Interfaces;
using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.SingleSignOn;
using Facesign.Services.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Facesign.Services.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SingleSignOnController : Controller
    {
        
        private readonly ITokenApp _token;
        private readonly ISingleSignOnRepository _singleSignOn;

        public SingleSignOnController( ITokenApp token, ISingleSignOnRepository singleSignOn)
        {           
            _token = token;
            _singleSignOn = singleSignOn;
        }

        [HttpPost]
        public async Task<ActionResult> Validate([FromBody] CodingModel coding)
        {
            try
            {
                var result = _token.DecryptUser(coding);


                var r = JsonConvert.DeserializeObject<TokenModel>(result);

                if (DateTime.Compare(r.dataExp, DateTime.Now) < 0)
                    return BadRequest("Token Expirado");
                else
                    return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao descodificar");
            }
        }
        [HttpPost]
        public async Task<JsonResult> Auth([FromBody] CodingModel coding)
        {
            try
            {
                var result = _token.EncryptUser(coding);

                return Json(new { token = result });

            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] SSOModel sso)
        {
            try
            {
                _singleSignOn.Create(sso);

                return Ok();

            }
            catch (Exception)
            {
                return BadRequest("Erro ao registrar SSO.");
            }
        }
    }
}
