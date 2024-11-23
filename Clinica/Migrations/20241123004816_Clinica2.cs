using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica.Migrations
{
    /// <inheritdoc />
    public partial class Clinica2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_cita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Personas_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_Personas_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Historial_Clinicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial_Clinicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historial_Clinicos_Personas_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoLlamadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCita = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoLlamadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoLlamadas_Citas_IdCita",
                        column: x => x.IdCita,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoLlamadas_Personas_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideoLlamadas_Personas_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdHistorialClinico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamientos_Historial_Clinicos_IdHistorialClinico",
                        column: x => x.IdHistorialClinico,
                        principalTable: "Historial_Clinicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tratamientos_Personas_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tratamientos_Personas_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdMedico",
                table: "Citas",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdPaciente",
                table: "Citas",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Clinicos_IdPaciente",
                table: "Historial_Clinicos",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_IdHistorialClinico",
                table: "Tratamientos",
                column: "IdHistorialClinico");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_IdMedico",
                table: "Tratamientos",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_IdPaciente",
                table: "Tratamientos",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_VideoLlamadas_IdCita",
                table: "VideoLlamadas",
                column: "IdCita");

            migrationBuilder.CreateIndex(
                name: "IX_VideoLlamadas_IdMedico",
                table: "VideoLlamadas",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_VideoLlamadas_IdPaciente",
                table: "VideoLlamadas",
                column: "IdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "VideoLlamadas");

            migrationBuilder.DropTable(
                name: "Historial_Clinicos");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
