using Actividades.Core.Model;
using Actividades.Core.Model.Base;
using Actividades.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Actividades.Data
{
    public class ActividadContext : DbContext
    {
        public ActividadContext(DbContextOptions<ActividadContext> options ): base (options)
        {
        }

        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ValidarEntidades();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ValidarEntidades();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ValidarEntidades();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected void ValidarEntidades()
        {
            List<IValidEntity> entidades = ChangeTracker.Entries()
                .Where(x => (x.Entity.GetType().IsAssignableFrom(typeof(IValidEntity)))).Select(x => (IValidEntity)x.Entity)
                .ToList();

            foreach (var entity in entidades)
            {
                entity.IsValid();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActividadMap());
            modelBuilder.ApplyConfiguration(new MultimediaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
