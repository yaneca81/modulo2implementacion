using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleMedicina.Data;
using TeleMedicina.Models;

namespace TeleMedicina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DataTelemedicina _context;

        public PacienteController(DataTelemedicina context)
        {
            _context = context;
        }

        // GET: api/Paciente/Listar
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return Ok(pacientes);
        }

        // POST: api/Paciente/Registrar
        [HttpPost("Registrar")]
        public async Task<ActionResult> PostPaciente(Paciente paciente)
        {
            if (_context.Pacientes == null)
            {
                return Problem("Entity set 'DataPractica.Pacientes' is null.");
            }

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return Ok("Paciente registrado correctamente.");
        }

        // GET: api/Paciente/BuscarId
        [HttpGet("BuscarId/{id}")]
        public async Task<ActionResult<Paciente>> GetPacienteId(int id)
        {
            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(p => p.IdPaciente == id);

            if (paciente == null)
            {
                return NotFound("Paciente no encontrado.");
            }

            return Ok(paciente);
        }

        // PUT: api/Paciente/Modificar
        [HttpPut("Modificar/{id}")]
        public async Task<ActionResult> PutPaciente(Paciente paciente, int id)
        {
            var existePaciente = await _context.Pacientes.FindAsync(id);
            if (existePaciente == null)
            {
                return NotFound("Paciente no encontrado.");
            }


            existePaciente.Nombre = paciente.Nombre;
            existePaciente.Apellido = paciente.Apellido;
            existePaciente.FechaNacimiento = paciente.FechaNacimiento;
            existePaciente.Telefono = paciente.Telefono;
            existePaciente.Direccion = paciente.Direccion;

            await _context.SaveChangesAsync();
            return Ok("Paciente modificado correctamente.");
        }
    }

}
