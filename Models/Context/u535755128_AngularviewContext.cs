using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models.Context
{
    public partial class u535755128_AngularviewContext : DbContext
    {
        public u535755128_AngularviewContext()
        {
        }

        public u535755128_AngularviewContext(DbContextOptions<u535755128_AngularviewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AltaExpositor> AltaExpositor { get; set; }
        public virtual DbSet<Caja> Caja { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Expositor> Expositor { get; set; }
        public virtual DbSet<ExpositorPago> ExpositorPago { get; set; }
        public virtual DbSet<MetodoDePago> MetodoDePago { get; set; }
        public virtual DbSet<PagosComision> PagosComision { get; set; }
        public virtual DbSet<ProductoServicio> ProductoServicio { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }
        public virtual DbSet<VentaEspacio> VentaEspacio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=31.170.160.103;database=u535755128_Angularview;user=u535755128_jers;password=Rtx2080_", x => x.ServerVersion("10.4.17-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AltaExpositor>(entity =>
            {
                entity.HasIndex(e => e.IdExpositor)
                    .HasName("FK_AltaExpositor_Expositor");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("FK_AltaExpositor_Vendedores");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdExpositor).HasColumnType("int(11)");

                entity.Property(e => e.IdVendedor).HasColumnType("int(11)");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.HasOne(d => d.IdExpositorNavigation)
                    .WithMany(p => p.AltaExpositor)
                    .HasForeignKey(d => d.IdExpositor)
                    .HasConstraintName("FK_AltaExpositor_Expositor");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.AltaExpositor)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_AltaExpositor_Vendedores");
            });

            modelBuilder.Entity<Caja>(entity =>
            {
                entity.HasIndex(e => e.IdEvento)
                    .HasName("FK_Caja_Evento");

                entity.HasIndex(e => e.IdSala)
                    .HasName("FK_Caja_Sala");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.Costo)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdEvento)
                    .HasColumnName("Id_Evento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSala)
                    .HasColumnName("Id_Sala")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Ocupado).HasColumnType("int(11)");

                entity.Property(e => e.Tipo).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Caja)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK_Caja_Evento");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Caja)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK_Caja_Sala");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Expositor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Celular)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Correo)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Negocio)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Registro).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<ExpositorPago>(entity =>
            {
                entity.ToTable("ExpositorPAgo");

                entity.HasIndex(e => e.IdExpositor)
                    .HasName("FK_ExpositorPAgo_Expositor");

                entity.HasIndex(e => e.IdTipoPago)
                    .HasName("FK_ExpositorPAgo_MetodoDePago");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.IdExpositor).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoPago).HasColumnType("int(11)");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.HasOne(d => d.IdExpositorNavigation)
                    .WithMany(p => p.ExpositorPago)
                    .HasForeignKey(d => d.IdExpositor)
                    .HasConstraintName("FK_ExpositorPAgo_Expositor");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.ExpositorPago)
                    .HasForeignKey(d => d.IdTipoPago)
                    .HasConstraintName("FK_ExpositorPAgo_MetodoDePago");
            });

            modelBuilder.Entity<MetodoDePago>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Modifacdo)
                    .HasColumnName("modifacdo")
                    .HasColumnType("datetime");

                entity.Property(e => e.TpoDePago)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PagosComision>(entity =>
            {
                entity.HasIndex(e => e.IdVendedor)
                    .HasName("FK_PagosComision_Vendedores");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdVendedor)
                    .HasColumnName("Id_Vendedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pago).HasColumnType("decimal(28,4)");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.PagosComision)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_PagosComision_Vendedores");
            });

            modelBuilder.Entity<ProductoServicio>(entity =>
            {
                entity.HasIndex(e => e.IdExpositor)
                    .HasName("FK_ProductoServicio_Expositor");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.Decripcion)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Descuento).HasColumnType("int(11)");

                entity.Property(e => e.IdExpositor)
                    .HasColumnName("Id_Expositor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PrecioDescuento).HasColumnType("decimal(28,2)");

                entity.Property(e => e.PrecioNormal).HasColumnType("decimal(28,2)");

                entity.Property(e => e.Stock).HasColumnType("int(11)");

                entity.Property(e => e.Tipo).HasColumnType("int(11)");

                entity.HasOne(d => d.IdExpositorNavigation)
                    .WithMany(p => p.ProductoServicio)
                    .HasForeignKey(d => d.IdExpositor)
                    .HasConstraintName("FK_ProductoServicio_Expositor");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasIndex(e => e.IdEvento)
                    .HasName("FK_Sala_Evento");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.Espacios).HasColumnType("int(11)");

                entity.Property(e => e.IdEvento)
                    .HasColumnName("Id_Evento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NumeroSala)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TipoSala).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Sala)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK_Sala_Evento");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.Correo)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Registro).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Vendedores>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.Comision).HasColumnType("decimal(28,2)");

                entity.Property(e => e.Correo)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FechaCaducidad).HasColumnType("datetime");

                entity.Property(e => e.IdFreelance)
                    .HasColumnName("Id_Freelance")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Passworsd)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Token)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<VentaEspacio>(entity =>
            {
                entity.HasIndex(e => e.IdCajon)
                    .HasName("FK_VentaEspacio_Caja");

                entity.HasIndex(e => e.IdExpositor)
                    .HasName("FK_VentaEspacio_Expositor");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("FK_VentaEspacio_Vendedores");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Estatus).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdCajon)
                    .HasColumnName("Id_Cajon")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdExpositor)
                    .HasColumnName("Id_Expositor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVendedor)
                    .HasColumnName("Id_Vendedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Total).HasColumnType("decimal(28,2)");

                entity.HasOne(d => d.IdCajonNavigation)
                    .WithMany(p => p.VentaEspacio)
                    .HasForeignKey(d => d.IdCajon)
                    .HasConstraintName("FK_VentaEspacio_Caja");

                entity.HasOne(d => d.IdExpositorNavigation)
                    .WithMany(p => p.VentaEspacio)
                    .HasForeignKey(d => d.IdExpositor)
                    .HasConstraintName("FK_VentaEspacio_Expositor");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.VentaEspacio)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_VentaEspacio_Vendedores");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
