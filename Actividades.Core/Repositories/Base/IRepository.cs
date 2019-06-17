using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.Core.Repositories.Base
{
    /// <summary>
    /// Repositorio base
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Guardar los cambios en la bd
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync(); 
    }
}
