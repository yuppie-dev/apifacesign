using Facesign.Services.Application.AppService;
using Facesign.Services.Application.Interfaces;
using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.Configuration;
using Facesign.Services.Entities.Signature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yuppie.LockID.Entities.Signature;

namespace Facesign.Services.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SignatureController : Controller
    {

        private readonly ISignatureRepositoryApp _signatureRepository;

        private readonly IClientsRepository _clientsRepository;
                    

        public SignatureController(
                                   ISignatureRepositoryApp signatureRepository,  IClientsRepository clientsRepository)
        {
            _signatureRepository = signatureRepository;
            _clientsRepository = clientsRepository;           
        }

        [HttpPost]
        public JsonResult GetById(Guid id)
        {

          

            return Json("");

        }

        //[HttpPost]
        //public JsonResult Authenticator([FromBody] SignatureChaveModel chave)
        //{
        //    string token = null;

        //    try
        //    {
        //      //  var result = _signatureRepository.userSignature(chave.chave);
        //      //  if (result.Result != null)
        //      //  {
        //     //       token = _tokenApp.TokenGenerator(result.Result.id.ToString());
        //      //  }

        //    }
        //    catch (Exception)
        //    {
        //    }

        //    return Json(new { token = token });
        //}

        [HttpPost]
      //  [Authorize]
        public IActionResult Validator([FromBody] Guid chave)
        {
           
            var result = _signatureRepository.validatorSignature(chave);

            return Ok(result);
        }


        [HttpPost]
     //   [Authorize]
        public JsonResult Generate([FromBody] SignatureChaveModel chave)
        {
            var validade = _clientsRepository.Validator(chave.clienteId);

            if (validade)
            {
                var result = _signatureRepository.generatorSignature();

                return Json(new { token =  string.Format("{0}/Home/{1}", BuildConfigurationModel.EndpointFrontEnd, result) });
            }
            else
                return Json(null);
            
        }


        [HttpPost]
      //  [Authorize]
        public IActionResult Create([FromBody] SignatureModelRequest modelRequest)
        {

            var model = new SignatureModel
            {
                id = modelRequest.id,                
                cpf = modelRequest.cpf.Trim().Replace(" ",""),
                image = ConvertImage(modelRequest.image),
                matchLevel  = modelRequest.matchLevel,
                ip = modelRequest.ip,
                deviceModel = modelRequest.deviceModel,
                location= modelRequest.location,
               
            };

            _signatureRepository.saveSignature(model);
            return Ok();
        }

        internal byte[] ConvertImage(string hash)
        {
            byte[] binaryData = Convert.FromBase64String(hash);
            return binaryData;
        }
    }
}
