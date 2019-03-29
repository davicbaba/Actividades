using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividades.Core.DTO.Input.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Actividades.WebApi.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            return Ok();
        }
        [HttpPost("registros")]
        public IActionResult GetLista([FromBody] UsuarioGetListaInput data)
        {
            return Ok();
        }

       

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromRoute] string id, [FromBody] JsonPatchDocument<UsuarioInput> data)
        {
            return Ok();
        }
    }
}