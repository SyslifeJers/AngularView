using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularView.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Apellidos = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expositor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Correo = table.Column<string>(type: "varchar(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Password = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    Registro = table.Column<DateTime>(type: "datetime", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Apellidos = table.Column<string>(type: "varchar(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Activo = table.Column<int>(type: "int(11)", nullable: true),
                    Modificado = table.Column<DateTime>(type: "datetime", nullable: true),
                    Celular = table.Column<string>(type: "varchar(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Negocio = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expositor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodoDePago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TpoDePago = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    activo = table.Column<int>(type: "int(11)", nullable: true),
                    modifacdo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoDePago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Correo = table.Column<string>(type: "varchar(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Password = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    Registro = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<int>(type: "int(11)", nullable: true),
                    Modificado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Freelance = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    Correo = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Passworsd = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Activo = table.Column<int>(type: "int(11)", nullable: true),
                    Modificado = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comision = table.Column<decimal>(type: "decimal(28,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroSala = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    TipoSala = table.Column<int>(type: "int(11)", nullable: true),
                    Activo = table.Column<int>(type: "int(11)", nullable: true),
                    Modificado = table.Column<DateTime>(type: "datetime", nullable: true),
                    Espacios = table.Column<int>(type: "int(11)", nullable: true),
                    Id_Evento = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sala_Evento",
                        column: x => x.Id_Evento,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Decripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    PrecioNormal = table.Column<decimal>(type: "decimal(28,2)", nullable: true),
                    PrecioDescuento = table.Column<decimal>(type: "decimal(28,2)", nullable: true),
                    Descuento = table.Column<int>(type: "int(11)", nullable: true),
                    Tipo = table.Column<int>(type: "int(11)", nullable: true),
                    Activo = table.Column<int>(type: "int(11)", nullable: true),
                    Modificado = table.Column<DateTime>(type: "datetime", nullable: true),
                    Stock = table.Column<int>(type: "int(11)", nullable: true),
                    Id_Expositor = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoServicio_Expositor",
                        column: x => x.Id_Expositor,
                        principalTable: "Expositor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpositorPAgo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdExpositor = table.Column<int>(type: "int(11)", nullable: true),
                    IdTipoPago = table.Column<int>(type: "int(11)", nullable: true),
                    Activo = table.Column<int>(type: "int(11)", nullable: true),
                    Modificado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpositorPAgo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpositorPAgo_Expositor",
                        column: x => x.IdExpositor,
                        principalTable: "Expositor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpositorPAgo_MetodoDePago",
                        column: x => x.IdTipoPago,
                        principalTable: "MetodoDePago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AltaExpositor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdVendedor = table.Column<int>(type: "int(11)", nullable: true),
                    IdExpositor = table.Column<int>(type: "int(11)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<int>(type: "int(11)", nullable: true),
                    Modificado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltaExpositor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AltaExpositor_Expositor",
                        column: x => x.IdExpositor,
                        principalTable: "Expositor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AltaExpositor_Vendedores",
                        column: x => x.IdVendedor,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagosComision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pago = table.Column<decimal>(type: "decimal(28,4)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<int>(type: "int(11)", nullable: true),
                    Id_Vendedor = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosComision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagosComision_Vendedores",
                        column: x => x.Id_Vendedor,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Caja",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Id_Sala = table.Column<int>(type: "int(11)", nullable: true),
                    Id_Evento = table.Column<int>(type: "int(11)", nullable: true),
                    Tipo = table.Column<int>(type: "int(11)", nullable: true),
                    Activo = table.Column<int>(type: "int(11)", nullable: true),
                    Modificado = table.Column<DateTime>(type: "datetime", nullable: true),
                    Costo = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Ocupado = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caja", x => x.id);
                    table.ForeignKey(
                        name: "FK_Caja_Evento",
                        column: x => x.Id_Evento,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Caja_Sala",
                        column: x => x.Id_Sala,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VentaEspacio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Expositor = table.Column<int>(type: "int(11)", nullable: true),
                    Id_Cajon = table.Column<int>(type: "int(11)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    Id_Vendedor = table.Column<int>(type: "int(11)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(28,2)", nullable: true),
                    Estatus = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaEspacio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaEspacio_Caja",
                        column: x => x.Id_Cajon,
                        principalTable: "Caja",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VentaEspacio_Expositor",
                        column: x => x.Id_Expositor,
                        principalTable: "Expositor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VentaEspacio_Vendedores",
                        column: x => x.Id_Vendedor,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_AltaExpositor_Expositor",
                table: "AltaExpositor",
                column: "IdExpositor");

            migrationBuilder.CreateIndex(
                name: "FK_AltaExpositor_Vendedores",
                table: "AltaExpositor",
                column: "IdVendedor");

            migrationBuilder.CreateIndex(
                name: "FK_Caja_Evento",
                table: "Caja",
                column: "Id_Evento");

            migrationBuilder.CreateIndex(
                name: "FK_Caja_Sala",
                table: "Caja",
                column: "Id_Sala");

            migrationBuilder.CreateIndex(
                name: "FK_ExpositorPAgo_Expositor",
                table: "ExpositorPAgo",
                column: "IdExpositor");

            migrationBuilder.CreateIndex(
                name: "FK_ExpositorPAgo_MetodoDePago",
                table: "ExpositorPAgo",
                column: "IdTipoPago");

            migrationBuilder.CreateIndex(
                name: "FK_PagosComision_Vendedores",
                table: "PagosComision",
                column: "Id_Vendedor");

            migrationBuilder.CreateIndex(
                name: "FK_ProductoServicio_Expositor",
                table: "ProductoServicio",
                column: "Id_Expositor");

            migrationBuilder.CreateIndex(
                name: "FK_Sala_Evento",
                table: "Sala",
                column: "Id_Evento");

            migrationBuilder.CreateIndex(
                name: "FK_VentaEspacio_Caja",
                table: "VentaEspacio",
                column: "Id_Cajon");

            migrationBuilder.CreateIndex(
                name: "FK_VentaEspacio_Expositor",
                table: "VentaEspacio",
                column: "Id_Expositor");

            migrationBuilder.CreateIndex(
                name: "FK_VentaEspacio_Vendedores",
                table: "VentaEspacio",
                column: "Id_Vendedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltaExpositor");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ExpositorPAgo");

            migrationBuilder.DropTable(
                name: "PagosComision");

            migrationBuilder.DropTable(
                name: "ProductoServicio");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VentaEspacio");

            migrationBuilder.DropTable(
                name: "MetodoDePago");

            migrationBuilder.DropTable(
                name: "Caja");

            migrationBuilder.DropTable(
                name: "Expositor");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Evento");
        }
    }
}
