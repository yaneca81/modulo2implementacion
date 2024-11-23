using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica2Mod.Migrations
{
    /// <inheritdoc />
    public partial class migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capacitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(name: "Fecha_Inicio", type: "datetime2", nullable: false),
                    FechaCulminacion = table.Column<DateTime>(name: "Fecha_Culminacion", type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ci = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Capacitaciones_Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCapacitacion = table.Column<int>(type: "int", nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitaciones_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Capacitaciones_Empleados_Capacitaciones_IdCapacitacion",
                        column: x => x.IdCapacitacion,
                        principalTable: "Capacitaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Capacitaciones_Empleados_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nominas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SueldoBase = table.Column<int>(name: "Sueldo_Base", type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(name: "Fecha_Ingreso", type: "datetime2", nullable: false),
                    HorarioAsignado = table.Column<string>(name: "Horario_Asignado", type: "nvarchar(max)", nullable: false),
                    DiasTrabajados = table.Column<int>(name: "Dias_Trabajados", type: "int", nullable: false),
                    Pagosextras = table.Column<int>(name: "Pagos_extras", type: "int", nullable: false),
                    Permisos = table.Column<int>(type: "int", nullable: false),
                    TotalDescuentos = table.Column<int>(name: "Total_Descuentos", type: "int", nullable: false),
                    Sueldototal = table.Column<int>(name: "Sueldo_total", type: "int", nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nominas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nominas_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPermiso = table.Column<DateTime>(name: "Fecha_Permiso", type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permisos_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(name: "Fecha_Inicio", type: "datetime2", nullable: false),
                    FechaCulminacion = table.Column<DateTime>(name: "Fecha_Culminacion", type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacaciones_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_Empleados_IdCapacitacion",
                table: "Capacitaciones_Empleados",
                column: "IdCapacitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_Empleados_IdEmpleado",
                table: "Capacitaciones_Empleados",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Nominas_IdEmpleado",
                table: "Nominas",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_IdEmpleado",
                table: "Permisos",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Vacaciones_IdEmpleado",
                table: "Vacaciones",
                column: "IdEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capacitaciones_Empleados");

            migrationBuilder.DropTable(
                name: "Nominas");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Vacaciones");

            migrationBuilder.DropTable(
                name: "Capacitaciones");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
