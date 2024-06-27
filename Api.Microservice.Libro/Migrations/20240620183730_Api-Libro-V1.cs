﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Microservice.Libro.Migrations
{
    /// <inheritdoc />
    public partial class ApiLibroV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibreriasMaterial",
                columns: table => new
                {
                    LibreriaMaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutorLibro = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibreriasMaterial", x => x.LibreriaMaterialId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibreriasMaterial");
        }
    }
}
