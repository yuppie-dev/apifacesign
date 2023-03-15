using Facesign.Services.Application.Interfaces;
using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.User;
using Facesign.Services.Entities.Value;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Facesign.Services.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly IUserRepository _user;
        
        public UserController(IUserRepository user)
        {
            _user = user;           
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            try
            {
                var result = await _user.Get();
                if (result == null || result.Count == 0)
                    return Ok("Nenhum cliente encontrado");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao obter clientes");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> GetbyId([FromBody] Guid id)
        {
            try
            {
                var result = await _user.Get(id);
                if (result == null)
                    return Ok(null);
                else
                {                   
                    return Ok(result);
                }                    
            }
            catch
            {
                return BadRequest("Erro ao obter cliente");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> GetByCPF([FromBody] string cpf)
        {
            try
            {
                var result = await _user.Get(cpf);
                if (result == null)
                    return Ok(null);
                else
                    return Ok(result);
            }
            catch
            {
                return BadRequest("Erro ao obter cliente");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserModel user)
        {
            try
            {
                var result = _user.Create(user);
                if (result == Guid.Empty)
                    return BadRequest("Cliente não adicionado");
                else
                    return Ok(result);
            }
            catch
            {
                return BadRequest("Erro ao adicionar cliente");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserModel user)
        {
            try
            {
                _user.Update(user);
                return Ok();
            }
            catch
            {
                return BadRequest("Erro ao adicionar cliente");
            }
        }

        //[HttpPost]
        //public IActionResult ValueVerify([FromBody] ValueVerifyModel valueVerify)
        //{           

        //    var result = _user.CPFVerify(valueVerify);

        //    return Ok(result.Result);
        //}

       
    }
}
