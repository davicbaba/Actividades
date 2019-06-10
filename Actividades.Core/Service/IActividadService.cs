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
        /// Obtener una lista de actividades
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<Actividad> GetListaActividades(int[] ids);

        /// <summary>
        /// Elimina una actividad.
        /// </summary>
        /// <returns></returns>
        Task DeleteActividad();

        /// <summary>
        /// Agrega una actividad
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task AddActividad(ActividadInput data);
    }
}
