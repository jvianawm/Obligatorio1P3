﻿// <auto-generated />
using System;
using LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(PlataformaContext))]
    [Migration("20231019180426_inicialx")]
    partial class inicialx
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmenazaEcosistema", b =>
                {
                    b.Property<int>("AmenazasId")
                        .HasColumnType("int");

                    b.Property<int>("EcosistemasId")
                        .HasColumnType("int");

                    b.HasKey("AmenazasId", "EcosistemasId");

                    b.HasIndex("EcosistemasId");

                    b.ToTable("AmenazaEcosistema");
                });

            modelBuilder.Entity("AmenazaEspecie", b =>
                {
                    b.Property<int>("AmenazasId")
                        .HasColumnType("int");

                    b.Property<int>("EspeciesId")
                        .HasColumnType("int");

                    b.HasKey("AmenazasId", "EspeciesId");

                    b.HasIndex("EspeciesId");

                    b.ToTable("AmenazaEspecie");
                });

            modelBuilder.Entity("EcosistemaPais", b =>
                {
                    b.Property<int>("EcosistemasId")
                        .HasColumnType("int");

                    b.Property<int>("PaisesId")
                        .HasColumnType("int");

                    b.HasKey("EcosistemasId", "PaisesId");

                    b.HasIndex("PaisesId");

                    b.ToTable("EcosistemaPais");
                });

            modelBuilder.Entity("EcosistemasEspecies", b =>
                {
                    b.Property<int>("EcosistemasId")
                        .HasColumnType("int");

                    b.Property<int>("EspeciesId")
                        .HasColumnType("int");

                    b.HasKey("EcosistemasId", "EspeciesId");

                    b.HasIndex("EspeciesId");

                    b.ToTable("EcosistemasEspecies", (string)null);
                });

            modelBuilder.Entity("EcosistemasEspeciesPosibles", b =>
                {
                    b.Property<int>("EcosistemasPosiblesId")
                        .HasColumnType("int");

                    b.Property<int>("EspeciesPosiblesId")
                        .HasColumnType("int");

                    b.HasKey("EcosistemasPosiblesId", "EspeciesPosiblesId");

                    b.HasIndex("EspeciesPosiblesId");

                    b.ToTable("EcosistemasEspeciesPosibles", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Amenaza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradoPeligrosidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Amenazas");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Ecosistema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArchivoImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionCaracteristicas")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("EstadoConservacionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Latitud")
                        .HasColumnType("decimal(9,6)");

                    b.Property<decimal>("Longitud")
                        .HasColumnType("decimal(9,6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoConservacionId");

                    b.ToTable("Ecosistemas");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Especie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArchivoImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoConservacionId")
                        .HasColumnType("int");

                    b.Property<decimal?>("LongitudMaxima")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal?>("LongitudMinima")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("NombreVulgar")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PesoMaximo")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("PesoMinimo")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoConservacionId");

                    b.ToTable("Especies");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.EstadoConservacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EstadoConservacion");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEntidad")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoEntidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordEncriptado")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("LogicaNegocio.Parametros.Parametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Parametros");
                });

            modelBuilder.Entity("AmenazaEcosistema", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Amenaza", null)
                        .WithMany()
                        .HasForeignKey("AmenazasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Ecosistema", null)
                        .WithMany()
                        .HasForeignKey("EcosistemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AmenazaEspecie", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Amenaza", null)
                        .WithMany()
                        .HasForeignKey("AmenazasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Especie", null)
                        .WithMany()
                        .HasForeignKey("EspeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemaPais", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Ecosistema", null)
                        .WithMany()
                        .HasForeignKey("EcosistemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Pais", null)
                        .WithMany()
                        .HasForeignKey("PaisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemasEspecies", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Ecosistema", null)
                        .WithMany()
                        .HasForeignKey("EcosistemasId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Especie", null)
                        .WithMany()
                        .HasForeignKey("EspeciesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemasEspeciesPosibles", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Ecosistema", null)
                        .WithMany()
                        .HasForeignKey("EcosistemasPosiblesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Especie", null)
                        .WithMany()
                        .HasForeignKey("EspeciesPosiblesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Ecosistema", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("EstadoConservacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoConservacion");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Especie", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("EstadoConservacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LogicaNegocio.ValueObjects.DescripcionEspecie", "Descripcion", b1 =>
                        {
                            b1.Property<int>("EspecieId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Descripcion");

                            b1.HasKey("EspecieId");

                            b1.ToTable("Especies");

                            b1.WithOwner()
                                .HasForeignKey("EspecieId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.NombreCientifico", "NombreCientifico", b1 =>
                        {
                            b1.Property<int>("EspecieId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)")
                                .HasColumnName("NombreCientifico");

                            b1.HasKey("EspecieId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Especies");

                            b1.WithOwner()
                                .HasForeignKey("EspecieId");
                        });

                    b.Navigation("Descripcion")
                        .IsRequired();

                    b.Navigation("EstadoConservacion");

                    b.Navigation("NombreCientifico")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
