using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividades.Core.DTO.Input.Actividad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Actividades.WebApi.Controllers
{
    [Route("api/actividad")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            return Ok();
        }
        //[HttpPost("registros")]
        //public IActionResult GetLista([FromBody] ActividadGetListaInput data)
        //{
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult Post([FromBody] List<ActividadInput> data)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromRoute] string id, [FromBody] JsonPatchDocument<ActividadInput> data)
        {
            return Ok();
        }
    }
}