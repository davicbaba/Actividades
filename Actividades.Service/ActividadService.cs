using Actividades.Core.DTO.Input.Actividad;
using Actividades.Core.Exceptions;
using Actividades.Core.Model;
using Actividades.Core.Repositories;
using Actividades.Core.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.Service
{
    public class ActividadService : IActividadService
    {
        private readonly IActividadRepository _actividadRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public ActividadService(IActividadRepository actividadRepository, IUsuarioRepository usuarioRepository)
        {
            _actividadRepository = actividadRepository;
            _usuarioRepository = usuarioRepository;

            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<ActividadInput, Actividad>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<bool> AddActividad(ActividadInput data, string idUsuario)
        {
            Usuario usuario = await _usuarioRepository.GetUsuario(idUsuario);

            if(usuario == null)
                throw new EntityException($"El usuario {idUsuario} no existe");

            Actividad actividad = _mapper.Map<Actividad>(data);

            bool exito = usuario.IntentarGuardarActividad(actividad, data.Forzar);

            if(exito)
                await _actividadRepository.SaveChangesAsync();

            return exito;
        }

        public async Task DeleteActividad(int id)
        {
            Actividad act = await GetActividad(id);
     
            act.FechaBorrado = DateTime.Now;

            await _actividadRepository.SaveChangesAsync();
        }

        public async Task<Actividad> GetActividad(int id)
        {
            Actividad act = await _actividadRepository.GetActividad(id);

            if (act == null)
                throw new EntityException($"La actividad {id} no existe");

            return act;
        }

    }
}
