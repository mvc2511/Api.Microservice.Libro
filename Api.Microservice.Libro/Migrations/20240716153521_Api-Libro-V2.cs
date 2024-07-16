using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Microservice.Libro.Migrations
{
    /// <inheritdoc />
    public partial class ApiLibroV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "LibreriasMaterial",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "LibreriasMaterial");
        }
    }
}
