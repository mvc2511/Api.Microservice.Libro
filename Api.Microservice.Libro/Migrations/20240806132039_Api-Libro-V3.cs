using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Microservice.Libro.Migrations
{
    /// <inheritdoc />
    public partial class ApiLibroV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "LibreriasMaterial",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "LibreriasMaterial");
        }
    }
}
