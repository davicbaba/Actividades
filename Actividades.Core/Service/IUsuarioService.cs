using Actividades.Core.DTO.Input.Actividad;
using Actividades.Core.DTO.Output.Actividad;
using Actividades.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.Core.Service
{
    /// <summary>
    /// Servicio para la gestion de actividades
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Elimina una actividad.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Task DeleteActividad(int id, string idUsuario);

        /// <summary>
        /// Agrega una actividad
        /// </summary>
        /// <param name="data"></param>
        /// <param name="idUsuario"></param>
        /// <param name="forzar"></param>
        /// <returns></returns>
        Task<Actividad> AddActividad(Actividad data, string idUsuario, bool forzar );

        /// <summary>
        /// Obtener un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Task<Usuario> GetUsuario(string idUsuario);

    }
}
