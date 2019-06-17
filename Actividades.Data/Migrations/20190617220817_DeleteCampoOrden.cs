using Microsoft.EntityFrameworkCore.Migrations;

namespace Actividades.Data.Migrations
{
    public partial class DeleteCampoOrden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orden",
                table: "Actividad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Orden",
                table: "Actividad",
                nullable: false,
                defaultValue: 0);
        }
    }
}
