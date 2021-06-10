﻿// <auto-generated />
using System;
using AngularView.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularView.Migrations
{
    [DbContext(typeof(u535755128_AngularviewContext))]
    [Migration("20210608145504_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AngularView.Models.Context.AltaExpositor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdExpositor")
                        .HasColumnType("int(11)");

                    b.Property<int?>("IdVendedor")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdExpositor")
                        .HasName("FK_AltaExpositor_Expositor");

                    b.HasIndex("IdVendedor")
                        .HasName("FK_AltaExpositor_Vendedores");

                    b.ToTable("AltaExpositor");
                });

            modelBuilder.Entity("AngularView.Models.Context.Caja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnType("int(11)");

                    b.Property<string>("Costo")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<int?>("IdEvento")
                        .HasColumnName("Id_Evento")
                        .HasColumnType("int(11)");

                    b.Property<int?>("IdSala")
                        .HasColumnName("Id_Sala")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime");

                    b.Property<int?>("Ocupado")
                        .HasColumnType("int(11)");

                    b.Property<int?>("Tipo")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("IdEvento")
                        .HasName("FK_Caja_Evento");

                    b.HasIndex("IdSala")
                        .HasName("FK_Caja_Sala");

                    b.ToTable("Caja");
                });

            modelBuilder.Entity("AngularView.Models.Context.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("varchar(250)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AngularView.Models.Context.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("Id");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("AngularView.Models.Context.Expositor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnType("int(11)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("Celular")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("Correo")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime");

                    b.Property<string>("Negocio")
                        .HasColumnType("varchar(250)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(250)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<DateTime?>("Registro")
                        .HasColumnType("datetime");

                    b.Property<string>("Token")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_unicode_ci");

                    b.HasKey("Id");

                    b.ToTable("Expositor");
                });

            modelBuilder.Entity("AngularView.Models.Context.ExpositorPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnType("int(11)");

                    b.Property<int?>("IdExpositor")
                        .HasColumnType("int(11)");

                    b.Property<int?>("IdTipoPago")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdExpositor")
                        .HasName("FK_ExpositorPAgo_Expositor");

                    b.HasIndex("IdTipoPago")
                        .HasName("FK_ExpositorPAgo_MetodoDePago");

                    b.ToTable("ExpositorPAgo");
                });

            modelBuilder.Entity("AngularView.Models.Context.MetodoDePago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnName("activo")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Modifacdo")
                        .HasColumnName("modifacdo")
                        .HasColumnType("datetime");

                    b.Property<string>("TpoDePago")
                        .HasColumnType("varchar(250)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("Id");

                    b.ToTable("MetodoDePago");
                });

            modelBuilder.Entity("AngularView.Models.Context.PagosComision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdVendedor")
                        .HasColumnName("Id_Vendedor")
                        .HasColumnType("int(11)");

                    b.Property<decimal?>("Pago")
                        .HasColumnType("decimal(28,4)");

                    b.HasKey("Id");

                    b.HasIndex("IdVendedor")
                        .HasName("FK_PagosComision_Vendedores");

                    b.ToTable("PagosComision");
                });

            modelBuilder.Entity("AngularView.Models.Context.ProductoServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnType("int(11)");

                    b.Property<string>("Decripcion")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_unicode_ci");

                    b.Property<int?>("Descuento")
                        .HasColumnType("int(11)");

                    b.Property<int?>("IdExpositor")
                        .HasColumnName("Id_Expositor")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(250)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<decimal?>("PrecioDescuento")
                        .HasColumnType("decimal(28,2)");

                    b.Property<decimal?>("PrecioNormal")
                        .HasColumnType("decimal(28,2)");

                    b.Property<int?>("Stock")
                        .HasColumnType("int(11)");

                    b.Property<int?>("Tipo")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("IdExpositor")
                        .HasName("FK_ProductoServicio_Expositor");

                    b.ToTable("ProductoServicio");
                });

            modelBuilder.Entity("AngularView.Models.Context.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnType("int(11)");

                    b.Property<int?>("Espacios")
                        .HasColumnType("int(11)");

                    b.Property<int?>("IdEvento")
                        .HasColumnName("Id_Evento")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(250)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("NumeroSala")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<int?>("TipoSala")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("IdEvento")
                        .HasName("FK_Sala_Evento");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("AngularView.Models.Context.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnType("int(11)");

                    b.Property<string>("Correo")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(250)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<DateTime?>("Registro")
                        .HasColumnType("datetime");

                    b.Property<string>("Token")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_unicode_ci");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AngularView.Models.Context.Vendedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Activo")
                        .HasColumnType("int(11)");

                    b.Property<decimal?>("Comision")
                        .HasColumnType("decimal(28,2)");

                    b.Property<string>("Correo")
                        .HasColumnType("varchar(250)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<DateTime?>("FechaCaducidad")
                        .HasColumnType("datetime");

                    b.Property<string>("IdFreelance")
                        .HasColumnName("Id_Freelance")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("Passworsd")
                        .HasColumnType("varchar(250)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("Token")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_unicode_ci");

                    b.HasKey("Id");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("AngularView.Models.Context.VentaEspacio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Estatus")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdCajon")
                        .HasColumnName("Id_Cajon")
                        .HasColumnType("int(11)");

                    b.Property<int?>("IdExpositor")
                        .HasColumnName("Id_Expositor")
                        .HasColumnType("int(11)");

                    b.Property<int?>("IdVendedor")
                        .HasColumnName("Id_Vendedor")
                        .HasColumnType("int(11)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(28,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCajon")
                        .HasName("FK_VentaEspacio_Caja");

                    b.HasIndex("IdExpositor")
                        .HasName("FK_VentaEspacio_Expositor");

                    b.HasIndex("IdVendedor")
                        .HasName("FK_VentaEspacio_Vendedores");

                    b.ToTable("VentaEspacio");
                });

            modelBuilder.Entity("AngularView.Models.Context.AltaExpositor", b =>
                {
                    b.HasOne("AngularView.Models.Context.Expositor", "IdExpositorNavigation")
                        .WithMany("AltaExpositor")
                        .HasForeignKey("IdExpositor")
                        .HasConstraintName("FK_AltaExpositor_Expositor");

                    b.HasOne("AngularView.Models.Context.Vendedores", "IdVendedorNavigation")
                        .WithMany("AltaExpositor")
                        .HasForeignKey("IdVendedor")
                        .HasConstraintName("FK_AltaExpositor_Vendedores");
                });

            modelBuilder.Entity("AngularView.Models.Context.Caja", b =>
                {
                    b.HasOne("AngularView.Models.Context.Evento", "IdEventoNavigation")
                        .WithMany("Caja")
                        .HasForeignKey("IdEvento")
                        .HasConstraintName("FK_Caja_Evento");

                    b.HasOne("AngularView.Models.Context.Sala", "IdSalaNavigation")
                        .WithMany("Caja")
                        .HasForeignKey("IdSala")
                        .HasConstraintName("FK_Caja_Sala");
                });

            modelBuilder.Entity("AngularView.Models.Context.ExpositorPago", b =>
                {
                    b.HasOne("AngularView.Models.Context.Expositor", "IdExpositorNavigation")
                        .WithMany("ExpositorPago")
                        .HasForeignKey("IdExpositor")
                        .HasConstraintName("FK_ExpositorPAgo_Expositor");

                    b.HasOne("AngularView.Models.Context.MetodoDePago", "IdTipoPagoNavigation")
                        .WithMany("ExpositorPago")
                        .HasForeignKey("IdTipoPago")
                        .HasConstraintName("FK_ExpositorPAgo_MetodoDePago");
                });

            modelBuilder.Entity("AngularView.Models.Context.PagosComision", b =>
                {
                    b.HasOne("AngularView.Models.Context.Vendedores", "IdVendedorNavigation")
                        .WithMany("PagosComision")
                        .HasForeignKey("IdVendedor")
                        .HasConstraintName("FK_PagosComision_Vendedores");
                });

            modelBuilder.Entity("AngularView.Models.Context.ProductoServicio", b =>
                {
                    b.HasOne("AngularView.Models.Context.Expositor", "IdExpositorNavigation")
                        .WithMany("ProductoServicio")
                        .HasForeignKey("IdExpositor")
                        .HasConstraintName("FK_ProductoServicio_Expositor");
                });

            modelBuilder.Entity("AngularView.Models.Context.Sala", b =>
                {
                    b.HasOne("AngularView.Models.Context.Evento", "IdEventoNavigation")
                        .WithMany("Sala")
                        .HasForeignKey("IdEvento")
                        .HasConstraintName("FK_Sala_Evento");
                });

            modelBuilder.Entity("AngularView.Models.Context.VentaEspacio", b =>
                {
                    b.HasOne("AngularView.Models.Context.Caja", "IdCajonNavigation")
                        .WithMany("VentaEspacio")
                        .HasForeignKey("IdCajon")
                        .HasConstraintName("FK_VentaEspacio_Caja");

                    b.HasOne("AngularView.Models.Context.Expositor", "IdExpositorNavigation")
                        .WithMany("VentaEspacio")
                        .HasForeignKey("IdExpositor")
                        .HasConstraintName("FK_VentaEspacio_Expositor");

                    b.HasOne("AngularView.Models.Context.Vendedores", "IdVendedorNavigation")
                        .WithMany("VentaEspacio")
                        .HasForeignKey("IdVendedor")
                        .HasConstraintName("FK_VentaEspacio_Vendedores");
                });
#pragma warning restore 612, 618
        }
    }
}
