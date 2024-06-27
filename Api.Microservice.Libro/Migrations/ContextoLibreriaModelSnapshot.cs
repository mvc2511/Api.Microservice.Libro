﻿// <auto-generated />
using System;
using Api.Microservice.Libro.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Microservice.Libro.Migrations
{
    [DbContext(typeof(ContextoLibreria))]
    partial class ContextoLibreriaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
