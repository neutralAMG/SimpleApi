using Aplication.Contracts;
using Aplication.Dtos.Usuario;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServise usuarioSrrvise;
        public UsuarioController(IUsuarioServise usuarioServise)
        {
            this.usuarioSrrvise = usuarioServise;
        }
        // GET: api/<UsuarioController>
        [HttpGet("GetAllUsuarios")]
        public IActionResult Get()
        {
            var result = this.usuarioSrrvise.getEntities();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("GetUsuarioById")]
        public IActionResult Get(int id)
        {
            var result = this.usuarioSrrvise.getEntity(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetUsuarioBynameYContrasena")]
        public IActionResult GetUserByNameYContra(string name, string contrasena)
        {
            var result = this.usuarioSrrvise.GetUsuarioByNameYContra(name, contrasena);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<UsuarioController>
        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] UsuarioSaveDto usuarioSaveDto)
        {
            var result = this.usuarioSrrvise.SaveEntity(usuarioSaveDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("UpdateUsuario")]
        public IActionResult Put([FromBody] UsuarioUpdateDto usuarioUpdateDto)
        {
            var result = this.usuarioSrrvise.UpdateEntity(usuarioUpdateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("DeleteUsuario")]
        public IActionResult Delete(int id)
        {
            var result = this.usuarioSrrvise.DeleteEntity(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
