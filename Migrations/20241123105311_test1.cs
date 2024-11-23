using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actividad2_API_A2.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asociados",
                columns: table => new
                {
                    IdAsociado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asociados", x => x.IdAsociado);
                });

            migrationBuilder.CreateTable(
                name: "OfertasLaborales",
                columns: table => new
                {
                    IdOferta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertasLaborales", x => x.IdOferta);
                });

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    IdCuota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdAsociado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.IdCuota);
                    table.ForeignKey(
                        name: "FK_Cuotas_Asociados_IdAsociado",
                        column: x => x.IdAsociado,
                        principalTable: "Asociados",
                        principalColumn: "IdAsociado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumVitaes",
                columns: table => new
                {
                    IdCv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArchivoPdf = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FechaSubida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAsociado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumVitaes", x => x.IdCv);
                    table.ForeignKey(
                        name: "FK_CurriculumVitaes_Asociados_IdAsociado",
                        column: x => x.IdAsociado,
                        principalTable: "Asociados",
                        principalColumn: "IdAsociado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAsociado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_Eventos_Asociados_IdAsociado",
                        column: x => x.IdAsociado,
                        principalTable: "Asociados",
                        principalColumn: "IdAsociado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propuestas",
                columns: table => new
                {
                    IdPropuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArchivoPropuesta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdAsociado = table.Column<int>(type: "int", nullable: false),
                    IdOferta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propuestas", x => x.IdPropuesta);
                    table.ForeignKey(
                        name: "FK_Propuestas_Asociados_IdAsociado",
                        column: x => x.IdAsociado,
                        principalTable: "Asociados",
                        principalColumn: "IdAsociado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propuestas_OfertasLaborales_IdOferta",
                        column: x => x.IdOferta,
                        principalTable: "OfertasLaborales",
                        principalColumn: "IdOferta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_IdAsociado",
                table: "Cuotas",
                column: "IdAsociado");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVitaes_IdAsociado",
                table: "CurriculumVitaes",
                column: "IdAsociado");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdAsociado",
                table: "Eventos",
                column: "IdAsociado");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_IdAsociado",
                table: "Propuestas",
                column: "IdAsociado");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_IdOferta",
                table: "Propuestas",
                column: "IdOferta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "CurriculumVitaes");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Propuestas");

            migrationBuilder.DropTable(
                name: "Asociados");

            migrationBuilder.DropTable(
                name: "OfertasLaborales");
        }
    }
}
