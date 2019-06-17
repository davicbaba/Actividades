using Actividades.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Data.Mapping
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(Estado));

            builder.Property(x => x.Id).HasMaxLength(10);
            builder.Property(x => x.NombreEstado).HasMaxLength(25).IsRequired();
            builder.Property(x => x.DescripcionEstado).HasMaxLength(500).IsRequired();

        }
    }
}
