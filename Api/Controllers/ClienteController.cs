using Aplication.Contracts;
using Aplication.Dtos.Cliente;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;
        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }
        // GET: api/<ClienteController>
        [HttpGet("GetAllClientes")]
        public IActionResult Get()
        {
            var result = clienteService.getEntities();
            if (!result.IsSuccess)
            {
                BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<ClienteController>/5
        [HttpGet("GetClienteById")]
        public IActionResult Get(int id)
        {
            var result = clienteService.getEntity(id);
            if (!result.IsSuccess)
            {
                BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetClienteByUsuarioId")]
        public IActionResult GetBuUsuarioId(int id)
        {
            var result = clienteService.GetClienteByUsuarioId(id);
            if (!result.IsSuccess)
            {
                BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<ClienteController>
        [HttpPost("SaveCliente")]
        public IActionResult Post([FromBody] ClienteSaveDto clienteSaveDto)
        {
            var result = clienteService.SaveEntity(clienteSaveDto);
            if (!result.IsSuccess)
            {
                BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("UpdateCliente")]
        public IActionResult Put([FromBody] ClienteUpdateDto clienteUpdateDto)
        {
            var result = clienteService.UpdateEntity(clienteUpdateDto);
            if (!result.IsSuccess)
            {
                BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("DeleteCliente")]
        public IActionResult Delete(int id)
        {
            var result = clienteService.DeleteEntity(id);
            if (!result.IsSuccess)
            {
                BadRequest(result);
            }
            return Ok(result);
        }
    }
}
