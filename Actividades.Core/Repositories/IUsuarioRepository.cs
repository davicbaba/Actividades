using Actividades.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.Core.Repositories
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Obtener un usuario por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Usuario> GetUsuario(string id);
    }
}
