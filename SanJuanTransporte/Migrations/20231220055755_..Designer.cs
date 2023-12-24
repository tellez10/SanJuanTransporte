﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SanJuanTransporte.Context;

#nullable disable

namespace SanJuanTransporte.Migrations
{
    [DbContext(typeof(MiContext))]
    [Migration("20231220055755_.")]
    partial class _
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SanJuanTransporte.Models.Conductor", b =>
                {
                    b.Property<int>("ConductorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConductorId"));

                    b.Property<int>("CI")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroLicencia")
                        .HasColumnType("int");

                    b.Property<string>("NumeroPlaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConductorId");

                    b.ToTable("Conductor");
                });

            modelBuilder.Entity("SanJuanTransporte.Models.Pago", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagoId"));

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("ConductorId")
                        .HasColumnType("int");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("date");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("PagoId");

                    b.HasIndex("ConductorId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("SanJuanTransporte.Models.Recibo", b =>
                {
                    b.Property<int>("ReciboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReciboId"));

                    b.Property<string>("DetallesPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroRecibo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PagoId")
                        .HasColumnType("int");

                    b.HasKey("ReciboId");

                    b.HasIndex("PagoId");

                    b.ToTable("Recibos");
                });

            modelBuilder.Entity("SanJuanTransporte.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SanJuanTransporte.Models.Pago", b =>
                {
                    b.HasOne("SanJuanTransporte.Models.Conductor", "Conductor")
                        .WithMany("Pagos")
                        .HasForeignKey("ConductorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SanJuanTransporte.Models.Usuario", "Usuario")
                        .WithMany("Pagos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conductor");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SanJuanTransporte.Models.Recibo", b =>
                {
                    b.HasOne("SanJuanTransporte.Models.Pago", "Pago")
                        .WithMany("Recibo")
                        .HasForeignKey("PagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pago");
                });

            modelBuilder.Entity("SanJuanTransporte.Models.Conductor", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("SanJuanTransporte.Models.Pago", b =>
                {
                    b.Navigation("Recibo");
                });

            modelBuilder.Entity("SanJuanTransporte.Models.Usuario", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
