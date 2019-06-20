using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividades.Core.DTO.Output.Usuario;
using Actividades.Core.Exceptions;
using Actividades.Core.Model;
using Actividades.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Actividades.WebApi.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;

        }
        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> GetUsuario([FromRoute] string idUsuario)
        {
            try
            {
                Usuario usuario = await _usuarioService.GetUsuario(idUsuario);

                if (usuario == null)
                    return NotFound(idUsuario);

                UsuarioOutput usuarioOutput = _mapper.Map<UsuarioOutput>(usuario);

                return Ok(usuarioOutput);
            }
            catch (EntityException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}