﻿// <auto-generated />
using System;
using Actividades.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Actividades.Data.Migrations
{
    [DbContext(typeof(ActividadContext))]
    [Migration("20190616234524_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Actividades.Core.Model.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<DateTime?>("FechaBorrado");

                    b.Property<DateTime?>("FechaCambioEstado");

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<bool>("Finalizada");

                    b.Property<string>("IdEstado");

                    b.Property<string>("IdUsuario");

                    b.Property<int>("Orden");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Actividad");
                });

            modelBuilder.Entity("Actividades.Core.Model.Estado", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("DescripcionEstado")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Actividades.Core.Model.Multimedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("IdActividad");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("IdActividad");

                    b.ToTable("Multimedia");
                });

            modelBuilder.Entity("Actividades.Core.Model.Usuario", b =>
                {
                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("NotificacionActividadMinutos");

                    b.HasKey("UserName");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Actividades.Core.Model.Actividad", b =>
                {
                    b.HasOne("Actividades.Core.Model.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado");

                    b.HasOne("Actividades.Core.Model.Usuario")
                        .WithMany("Actividades")
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("Actividades.Core.Model.Multimedia", b =>
                {
                    b.HasOne("Actividades.Core.Model.Actividad")
                        .WithMany("Multimedias")
                        .HasForeignKey("IdActividad")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
