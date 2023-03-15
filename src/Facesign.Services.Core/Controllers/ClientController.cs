using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.Client;
using Microsoft.AspNetCore.Mvc;

namespace Facesign.Services.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IClientsFunctionalitiesRepository _clientsFunctionalitiesRepository;
        private readonly IClientsLayoutsRepository _clientsLayoutsRepository;

        public ClientController(IClientsRepository clientsRepository, IClientsFunctionalitiesRepository clientsConfsFunctionalitiesRepository, IClientsLayoutsRepository clientsConfsLayoutsRepository)
        {
            _clientsRepository = clientsRepository;
            _clientsFunctionalitiesRepository = clientsConfsFunctionalitiesRepository;
            _clientsLayoutsRepository = clientsConfsLayoutsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientSummaryModel>>> GetAll()
        {
            try
            {
                var result = await _clientsRepository.Get();

                if (result == null || result.Count == 0)
                    return BadRequest("Nenhum cliente encontrado");
                else
                    return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao obter clientes");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClientsModel>> GetById([FromBody] Guid id)
        {
            var result = await _clientsRepository.Get(id);
            if (result == null)
                return Ok(null);
            else
            {
                result.layout = await _clientsLayoutsRepository.GetByIdClientId(id);
                result.functionalitie = await _clientsFunctionalitiesRepository.GetByIdClientId(id);

                return Ok(result);

            }

        }

        [HttpPost]
        public async Task<ActionResult<ClientsModel>> GetByLayoutId([FromBody] Guid id)
        {
            var result = await _clientsLayoutsRepository.GetByIdAsync(id);
            if (result == null)
                return Ok(null);
            else
            {
                var client = await _clientsRepository.Get(result.id_client);
                client.layout = result;
                client.functionalitie = await _clientsFunctionalitiesRepository.GetByIdClientId(result.id_client);

                return Ok(client);
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<ClientsModel>> GetByCPF([FromBody] string cpf)
        //{
        //    try
        //    {
        //        var result = await _clientsRepository.Get(cpf);
        //        if (result == null)
        //            return Ok(null);
        //        else
        //            return Ok(result);
        //    }
        //    catch
        //    {
        //        return BadRequest("Erro ao obter cliente");
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ClientsModel client)
        {
            try
            {
                var id = _clientsRepository.Create(client);
                if (id == Guid.Empty)
                    return BadRequest("Cliente não adicionado");
                else
                {
                    if (id == Guid.Empty)
                        return BadRequest("Configuração não adicionada");
                    else
                    {
                        if (client.functionalitie != null && client.layout != null)
                        {
                            client.functionalitie.id_client = id;
                            client.layout.id_client = id;

                            var func = await _clientsFunctionalitiesRepository.Create(client.functionalitie);
                            var layout = await _clientsLayoutsRepository.Create(client.layout);
                            return Ok(layout);
                        }
                    }
                    return Ok(id);
                }
            }
            catch
            {
                return BadRequest("Erro ao adicionar cliente");
            }
        }

       

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ClientsModel client)
        {
            try
            {
                _clientsRepository.Update(client);

                _clientsLayoutsRepository.Update(client.layout);
                _clientsFunctionalitiesRepository.Update(client.functionalitie);
                return Ok("Cliente alterado com sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao alterar cliente");

            }

        }
    }
}
