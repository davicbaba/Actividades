using Actividades.Core.DTO.Input.Actividad;
using Actividades.Core.DTO.Output.Actividad;
using Actividades.Core.DTO.Output.Usuario;
using Actividades.Core.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividades.WebApi.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<ActividadInput, Actividad>();
            CreateMap<Actividad, ActividadOutput>();
            CreateMap<Usuario, UsuarioOutput>();

        }

    }
}
