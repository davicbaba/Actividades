using Actividades.Core.Model;
using Actividades.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ActividadContext _context;

        public UsuarioRepository(ActividadContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuario(string id)
        {
            return await _context.Usuario.FindAsync(id);
        }
    }
}
