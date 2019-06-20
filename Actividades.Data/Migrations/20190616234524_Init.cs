using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Actividades.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    NombreEstado = table.Column<string>(maxLength: 25, nullable: false),
                    DescripcionEstado = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    NotificacionActividadMinutos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaCambioEstado = table.Column<DateTime>(nullable: true),
                    FechaBorrado = table.Column<DateTime>(nullable: true),
                    Finalizada = table.Column<bool>(nullable: false),
                    Orden = table.Column<int>(nullable: false),
                    IdEstado = table.Column<string>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividad_Estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividad_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 200, nullable: false),
                    MimeType = table.Column<string>(maxLength: 20, nullable: false),
                    IdActividad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multimedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Multimedia_Actividad_IdActividad",
                        column: x => x.IdActividad,
                        principalTable: "Actividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_IdEstado",
                table: "Actividad",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_IdUsuario",
                table: "Actividad",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Multimedia_IdActividad",
                table: "Multimedia",
                column: "IdActividad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Multimedia");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
