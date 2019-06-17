using Actividades.Core.Model;
using Actividades.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.Data.Repositories
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly ActividadContext _context;

        public ActividadRepository(ActividadContext context)
        {
            _context = context;
        }

        public async Task AddActividad(Actividad actividad)
        {
            await _context.AddAsync(actividad);
        }

        public async Task<Actividad> GetActividad(int id)
        {
            return await _context.Actividad.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
