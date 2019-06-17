using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividades.Core.DTO.Input.Actividad;
using Actividades.Core.Exceptions;
using Actividades.Core.Model;
using Actividades.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Actividades.WebApi.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly IActividadService _actividadService;

        public ActividadController(IActividadService actividadService)
        {
            _actividadService = actividadService;
        }

        [HttpGet("{idUsuario}/actividad/{idActividad}")]
        public async Task<IActionResult> GetById([FromRoute] int idUsuario,[FromRoute] int idActividad)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{IdUsuario}/actividad")]
        public async Task<IActionResult> Post([FromBody] ActividadInput data, [FromRoute] string idUsuario)
        {
            bool exito = false;
            try
            {
                exito = await _actividadService.AddActividad(data, idUsuario);
            }
            catch (EntityException ex)
            {
                return BadRequest(ex.Message);
            }

            if(exito == false)
                return BadRequest("No se puede agregar la actividad porque no hay espacio en el horario del usuario para ella");

            return Ok();
        }
      
    }
}