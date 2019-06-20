using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividades.Core.DTO.Input.Actividad;
using Actividades.Core.DTO.Output.Actividad;
using Actividades.Core.Exceptions;
using Actividades.Core.Model;
using Actividades.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Actividades.WebApi.Controllers
{
    [Route("api/usuario/{idUsuario}")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public ActividadController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;

        }

        [HttpPost("actividad")]
        public async Task<IActionResult> AgregarActividad([FromBody] ActividadInput data, [FromRoute] string idUsuario)
        {
            try
            {
                Actividad actividad = _mapper.Map<Actividad>(data);

                await _usuarioService.AddActividad(actividad, idUsuario, data.Forzar);

                ActividadOutput actividadOutput = _mapper.Map<ActividadOutput>(actividad);

                return Ok(actividadOutput);
            }
            catch (EntityException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("actividad")]
        public async Task<IActionResult> GetActividades( [FromRoute] string idUsuario)
        {
            try
            {
                Usuario usuario = await _usuarioService.GetUsuario(idUsuario);

                if (usuario == null)
                    return NotFound(idUsuario);

                List<ActividadOutput> actividadOutput = _mapper.Map<List<ActividadOutput>>(usuario.Actividades);

                return Ok(actividadOutput);
            }
            catch (EntityException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}