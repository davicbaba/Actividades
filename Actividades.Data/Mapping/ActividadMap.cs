using Actividades.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Data.Mapping
{
    public class ActividadMap : IEntityTypeConfiguration<Actividad>
    {
        public void Configure(EntityTypeBuilder<Actividad> builder)
        {
            builder.ToTable(nameof(Actividad));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.Estado).WithMany().HasForeignKey(x => x.IdEstado);

            builder.HasMany(x => x.Multimedias).WithOne().HasForeignKey(x => x.IdActividad);
        }
    }
}
