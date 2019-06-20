using Actividades.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Data.Mapping
{
    public class MultimediaMap : IEntityTypeConfiguration<Multimedia>
    {
        public void Configure(EntityTypeBuilder<Multimedia> builder)
        {
            builder.ToTable(nameof(Multimedia));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MimeType).HasMaxLength(20).IsRequired();
            builder.Property(x => x.FileName).HasMaxLength(200).IsRequired();

        }
    }
}
