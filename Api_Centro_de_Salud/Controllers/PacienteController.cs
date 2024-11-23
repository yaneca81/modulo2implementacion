using Api_Centro_de_Salud.Data;
using Api_Centro_de_Salud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Centro_de_Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ConexionDB _context;
        public PacienteController(ConexionDB context)
        {
            _context = context;
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente()
        {
            var pacientes = await _context.Paciente.ToListAsync();
            return Ok(pacientes);
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Paciente>> Post(Paciente paciente)
        {
            var res = await _context.Paciente.AddAsync(paciente);
            await _context.SaveChangesAsync();
            return Ok("Se ha registrado el paciente");
        }
        [HttpGet("BuscarPaciente")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente(int id)
        {
            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Paciente>> Put(Paciente paciente, int id)
        {
            var existId = await _context.Paciente.FindAsync(id);
            if (existId == null)
            {
                return NotFound("No encontrado");
            }

            existId.Ci = paciente.Ci;
            existId.Nombres = paciente.Nombres;
            existId.Apellidos = paciente.Apellidos;
            existId.FechaNacimiento = paciente.FechaNacimiento;
            existId.FechaRegistro = paciente.FechaRegistro;
            existId.Direccion = paciente.Direccion;
            existId.Genero = paciente.Genero;
            existId.Telefono=paciente.Telefono;
            existId.Correo=paciente.Correo;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
    }
}
