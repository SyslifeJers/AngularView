using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class AngularViewContext : DbContext
    {
        public AngularViewContext()
        {
        }

        public AngularViewContext(DbContextOptions<AngularViewContext> options)
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=35.224.198.204;Database=AngularView; User=jers;Password=tenshi19");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AltaExpositor>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

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
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Costo).HasMaxLength(50);

                entity.Property(e => e.Descripcion).HasMaxLength(150);

                entity.Property(e => e.IdEvento).HasColumnName("Id_Evento");

                entity.Property(e => e.IdSala).HasColumnName("Id_Sala");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

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
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos).HasMaxLength(250);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(150);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(150);
            });

            modelBuilder.Entity<Expositor>(entity =>
            {
                entity.Property(e => e.Apellidos).HasMaxLength(150);

                entity.Property(e => e.Celular).HasMaxLength(150);

                entity.Property(e => e.Correo).HasMaxLength(150);

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Negocio).HasMaxLength(250);

                entity.Property(e => e.Nombre).HasMaxLength(150);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Registro).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExpositorPago>(entity =>
            {
                entity.ToTable("ExpositorPAgo");

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
                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Modifacdo)
                    .HasColumnName("modifacdo")
                    .HasColumnType("datetime");

                entity.Property(e => e.TpoDePago).HasMaxLength(250);
            });

            modelBuilder.Entity<PagosComision>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdVendedor).HasColumnName("Id_Vendedor");

                entity.Property(e => e.Pago).HasColumnType("decimal(28, 4)");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.PagosComision)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_PagosComision_Vendedores");
            });

            modelBuilder.Entity<ProductoServicio>(entity =>
            {
                entity.Property(e => e.IdExpositor).HasColumnName("Id_Expositor");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(250);

                entity.Property(e => e.PrecioDescuento).HasColumnType("decimal(28, 2)");

                entity.Property(e => e.PrecioNormal).HasColumnType("decimal(28, 2)");

                entity.HasOne(d => d.IdExpositorNavigation)
                    .WithMany(p => p.ProductoServicio)
                    .HasForeignKey(d => d.IdExpositor)
                    .HasConstraintName("FK_ProductoServicio_Expositor");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.Property(e => e.IdEvento).HasColumnName("Id_Evento");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(250);

                entity.Property(e => e.NumeroSala).HasMaxLength(50);

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Sala)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK_Sala_Evento");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Correo).HasMaxLength(150);

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Registro).HasColumnType("datetime");
            });

            modelBuilder.Entity<Vendedores>(entity =>
            {
                entity.Property(e => e.Comision).HasColumnType("decimal(28, 2)");

                entity.Property(e => e.Correo).HasMaxLength(250);

                entity.Property(e => e.FechaCaducidad).HasColumnType("datetime");

                entity.Property(e => e.IdFreelance)
                    .HasColumnName("Id_Freelance")
                    .HasMaxLength(50);

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Passworsd).HasMaxLength(250);
            });

            modelBuilder.Entity<VentaEspacio>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdCajon).HasColumnName("Id_Cajon");

                entity.Property(e => e.IdExpositor).HasColumnName("Id_Expositor");

                entity.Property(e => e.IdVendedor).HasColumnName("Id_Vendedor");

                entity.Property(e => e.Total).HasColumnType("decimal(28, 2)");

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
