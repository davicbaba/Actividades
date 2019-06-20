using Actividades.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));
            builder.HasKey(x => x.UserName);

            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.Nombres).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Apellidos).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Actividades).WithOne().HasForeignKey(x => x.IdUsuario);
        }
    }
}
