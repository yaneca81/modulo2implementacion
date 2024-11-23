using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica2.Migrations
{
    /// <inheritdoc />
    public partial class primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enfermeros",
                columns: table => new
                {
                    EnfermeroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NumeroLicencia = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeros", x => x.EnfermeroId);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NumeroLicencia = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                });

            migrationBuilder.CreateTable(
                name: "CitasMedicas",
                columns: table => new
                {
                    CitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitasMedicas", x => x.CitaId);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpedientesMedicos",
                columns: table => new
                {
                    ExpedienteMedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Antecedentes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpedientesMedicos", x => x.ExpedienteMedicoId);
                    table.ForeignKey(
                        name: "FK_ExpedientesMedicos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalizaciones",
                columns: table => new
                {
                    HospitalizacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroHabitacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    EnfermeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalizaciones", x => x.HospitalizacionId);
                    table.ForeignKey(
                        name: "FK_Hospitalizaciones_Enfermeros_EnfermeroId",
                        column: x => x.EnfermeroId,
                        principalTable: "Enfermeros",
                        principalColumn: "EnfermeroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalizaciones_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalizaciones_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_MedicoId",
                table: "CitasMedicas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_PacienteId",
                table: "CitasMedicas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpedientesMedicos_PacienteId",
                table: "ExpedientesMedicos",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizaciones_EnfermeroId",
                table: "Hospitalizaciones",
                column: "EnfermeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizaciones_MedicoId",
                table: "Hospitalizaciones",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizaciones_PacienteId",
                table: "Hospitalizaciones",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitasMedicas");

            migrationBuilder.DropTable(
                name: "ExpedientesMedicos");

            migrationBuilder.DropTable(
                name: "Hospitalizaciones");

            migrationBuilder.DropTable(
                name: "Enfermeros");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
