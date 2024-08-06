﻿// <auto-generated />
using System;
using Api.Microservice.Libro.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Microservice.Libro.Migrations
{
    [DbContext(typeof(ContextoLibreria))]
    [Migration("20240806132039_Api-Libro-V3")]
    partial class ApiLibroV3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.Microservice.Libro.Modelo.LibreriaMaterial", b =>
                {
                    b.Property<Guid?>("LibreriaMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AutorLibro")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("FechaPublicacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("Imagen")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<double>("Precio")
                        .HasColumnType("double precision");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LibreriaMaterialId");

                    b.ToTable("LibreriasMaterial");
                });
#pragma warning restore 612, 618
        }
    }
}
