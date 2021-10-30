using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
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
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Caja> Caja { get; set; }
        public virtual DbSet<ClickCajas> ClickCajas { get; set; }
        public virtual DbSet<ClickProdcuto> ClickProdcuto { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DetalleCaja> DetalleCaja { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Expositor> Expositor { get; set; }
        public virtual DbSet<ExpositorPago> ExpositorPago { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<MetodoDePago> MetodoDePago { get; set; }
        public virtual DbSet<PagosComision> PagosComision { get; set; }
        public virtual DbSet<ProductoServicio> ProductoServicio { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<TipoEnvio> TipoEnvio { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VentaEspacio> VentaEspacio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=31.170.160.103;database=u535755128_Angularview;user=u535755128_jers;password=Rtx2080_", x => x.ServerVersion("10.5.12-mariadb"));
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

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ClaimValue)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("RelacionAspNetRoleClaims");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.NormalizedName)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ClaimValue)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("RelacionAspNetUserClaims");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ProviderKey)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ProviderDisplayName)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.UserId)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RoleId)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.Property(e => e.UserId)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.LoginProvider)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Value)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 768 });

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.EmailConfirmed).HasColumnType("tinyint(4)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("tinyint(4)");

                entity.Property(e => e.NormalizedEmail)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.NormalizedUserName)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("tinyint(4)");

                entity.Property(e => e.SecurityStamp)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("tinyint(4)");

                entity.Property(e => e.UserName)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
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

            modelBuilder.Entity<ClickCajas>(entity =>
            {
                entity.ToTable("clickCajas");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("Relacioncliente");

                entity.HasIndex(e => new { e.IdCaja, e.IdCliente })
                    .HasName("id_caja");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCaja)
                    .HasColumnName("id_caja")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.ClickCajas)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RelacionCaja");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClickCajas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relacioncliente");
            });

            modelBuilder.Entity<ClickProdcuto>(entity =>
            {
                entity.ToTable("clickProdcuto");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("Relacionclientes");

                entity.HasIndex(e => new { e.IdProducto, e.IdCliente })
                    .HasName("id_Producto");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_Producto")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClickProdcuto)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("Relacionclientes");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ClickProdcuto)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("RelacionProducto");
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

                entity.Property(e => e.Contrasena)
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Correo)
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Token)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UtlConexion).HasColumnType("datetime");
            });

            modelBuilder.Entity<DetalleCaja>(entity =>
            {
                entity.HasIndex(e => e.IdCaja)
                    .HasName("RelacionExpositorDetalleCaja");

                entity.HasIndex(e => e.IdExpositor)
                    .HasName("RelacionCajaExpositor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Direccion)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IdCaja)
                    .HasColumnName("id_Caja")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdExpositor)
                    .HasColumnName("id_Expositor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.PaginaWeb)
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RazonSocial)
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RedFacebook)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RedInstagram)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RedWhats)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Resumen)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Rfc)
                    .HasColumnName("RFC")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Titulo)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.VideoYoutube)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.DetalleCaja)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RelacionExpositorDetalleCaja");

                entity.HasOne(d => d.IdExpositorNavigation)
                    .WithMany(p => p.DetalleCaja)
                    .HasForeignKey(d => d.IdExpositor)
                    .HasConstraintName("RelacionCajaExpositor");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
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

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
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

            modelBuilder.Entity<TipoEnvio>(entity =>
            {
                entity.HasIndex(e => e.IdExpo)
                    .HasName("RelacionTipoEnvio");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdExpo)
                    .HasColumnName("id_expo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.IdExpoNavigation)
                    .WithMany(p => p.TipoEnvio)
                    .HasForeignKey(d => d.IdExpo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RelacionTipoEnvio");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasIndex(e => e.IdExpo)
                    .HasName("Relacionexpositor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdExpo)
                    .HasColumnName("id_expo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.IdExpoNavigation)
                    .WithMany(p => p.TipoPago)
                    .HasForeignKey(d => d.IdExpo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relacionexpositor");
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

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasIndex(e => e.IdCliente)
                    .HasName("RleacionCLienteVenta");

                entity.HasIndex(e => e.IdExpositor)
                    .HasName("RelacionExpositorVenta");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnType("int(11)");

                entity.Property(e => e.DireccionClient)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnType("int(11)");

                entity.Property(e => e.IdExpositor).HasColumnType("int(11)");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Rfccliente)
                    .IsRequired()
                    .HasColumnName("RFCcliente")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Rzcliente)
                    .IsRequired()
                    .HasColumnName("RZcliente")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.TipoEnvio)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.TipoPago)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RleacionCLienteVenta");

                entity.HasOne(d => d.IdExpositorNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdExpositor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RelacionExpositorVenta");
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
