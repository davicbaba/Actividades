using Actividades.Core.DTO.Input.Actividad;
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
    public interface IActividadService
    {
        /// <summary>
        /// Retorna una actividad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Actividad> GetActividad(int id);

        /// <summary>
        /// Elimina una actividad.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteActividad(int id);

        /// <summary>
        /// Agrega una actividad
        /// </summary>
        /// <param name="data"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Task<bool> AddActividad(ActividadInput data, string idUsuario);


    }
}
