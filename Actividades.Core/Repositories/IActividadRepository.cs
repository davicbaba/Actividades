using Actividades.Core.Model;
using Actividades.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.Core.Repositories
{
    public interface IActividadRepository : IRepository
    {
        /// <summary>
        /// Obtener una actividad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Actividad> GetActividad(int id);

        /// <summary>
        /// Agregar una actividad
        /// </summary>
        /// <param name="actividad"></param>
        /// <returns></returns>
        Task AddActividad(Actividad actividad);

    }
}
