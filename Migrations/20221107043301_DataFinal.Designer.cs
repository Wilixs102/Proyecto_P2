﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_P1.Data;

#nullable disable

namespace Proyecto_P1.Migrations
{
    [DbContext(typeof(Proyecto_P1Context))]
    [Migration("20221107043301_DataFinal")]
    partial class DataFinal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proyecto_P1.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComentarioId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaPublicacion")
                        .HasColumnType("datetime2");

                    b.HasKey("ComentarioId");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Proyecto_P1.Models.Oferta", b =>
                {
                    b.Property<int>("OfertaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfertaId"), 1L, 1);

                    b.Property<float>("NuevoPrecio")
                        .HasColumnType("real");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("OfertaId");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("Proyecto_P1.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("VerificarContraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerificarCorreo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Proyecto_P1.Models.Zapatos", b =>
                {
                    b.Property<int>("IdZapatos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZapatos"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagen")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdZapatos");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Zapatos");
                });

            modelBuilder.Entity("Proyecto_P1.Models.Comentario", b =>
                {
                    b.HasOne("Proyecto_P1.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioIdUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto_P1.Models.Oferta", b =>
                {
                    b.HasOne("Proyecto_P1.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioIdUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto_P1.Models.Zapatos", b =>
                {
                    b.HasOne("Proyecto_P1.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
