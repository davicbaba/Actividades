using Actividades.Core.DTO.Input.Actividad;
using Actividades.Core.DTO.Output.Actividad;
using Actividades.Core.Exceptions;
using Actividades.Core.Model;
using Actividades.Core.Repositories;
using Actividades.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IActividadRepository _actividadRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IActividadRepository actividadRepository, IUsuarioRepository usuarioRepository)
        {
            _actividadRepository = actividadRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Actividad> AddActividad(Actividad act, string idUsuario, bool forzar)
        {
            Usuario usuario = await _usuarioRepository.GetUsuario(idUsuario);

            if(usuario == null)
                throw new EntityException($"El usuario {idUsuario} no existe");

            usuario.IntentarGuardarActividad(act, forzar);

            await _actividadRepository.SaveChangesAsync();

            return act;
        }

        public async Task DeleteActividad(int id, string idUsuario)
        {
            Usuario user = await GetUsuario(idUsuario);

            if(user == null)
                throw new EntityException($"El usuario {idUsuario} no existe");

            Actividad act = user.Actividades.SingleOrDefault(x => x.Id == id);

            if(act == null)
                throw new EntityException($"La actividad {id} no existe");

            act.FechaBorrado = DateTime.Now;

            await _actividadRepository.SaveChangesAsync();
        }

 
        public async Task<Usuario> GetUsuario(string idUsuario)
        {
            return await _usuarioRepository.GetUsuario(idUsuario);
        }
    }
}
