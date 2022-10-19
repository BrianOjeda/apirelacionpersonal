﻿// <auto-generated />
using System;
using ApiRelacionPersonas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiRelacionPersonas.Migrations
{
    [DbContext(typeof(RelacionPersonaDbContext))]
    [Migration("20221018213106_Relacion")]
    partial class Relacion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiRelacionPersonas.Domain.Entities.Sexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sexo");
                });

            modelBuilder.Entity("ApiRelacionPersonas.Domain.Nacionalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nacionalidad");
                });

            modelBuilder.Entity("ApiRelacionPersonas.Domain.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("NacionalidadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SexoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NacionalidadId");

                    b.HasIndex("SexoId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("ApiRelacionPersonas.Domain.Relacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PersonaHijoId")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId_Hijo")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId_Padre")
                        .HasColumnType("int");

                    b.Property<int?>("PersonaPadreId")
                        .HasColumnType("int");

                    b.Property<int>("TipoRelacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaHijoId");

                    b.HasIndex("PersonaPadreId");

                    b.ToTable("Relaciones");
                });

            modelBuilder.Entity("ApiRelacionPersonas.Domain.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("ApiRelacionPersonas.Domain.TipoRelacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Relacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoRelacions");
                });

            modelBuilder.Entity("ApiRelacionPersonas.Domain.Persona", b =>
                {
                    b.HasOne("ApiRelacionPersonas.Domain.Nacionalidad", "Nacionalidad")
                        .WithMany()
                        .HasForeignKey("NacionalidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRelacionPersonas.Domain.Entities.Sexo", "Sexo")
                        .WithMany()
                        .HasForeignKey("SexoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRelacionPersonas.Domain.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nacionalidad");

                    b.Navigation("Sexo");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("ApiRelacionPersonas.Domain.Relacion", b =>
                {
                    b.HasOne("ApiRelacionPersonas.Domain.Persona", "PersonaHijo")
                        .WithMany()
                        .HasForeignKey("PersonaHijoId");

                    b.HasOne("ApiRelacionPersonas.Domain.Persona", "PersonaPadre")
                        .WithMany()
                        .HasForeignKey("PersonaPadreId");

                    b.Navigation("PersonaHijo");

                    b.Navigation("PersonaPadre");
                });
#pragma warning restore 612, 618
        }
    }
}