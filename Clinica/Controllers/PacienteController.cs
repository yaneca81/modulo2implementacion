using Clinia.Data;
using Clinia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DataClinica _context;

        public PacienteController(DataClinica context)
        {
            _context = context;
        }

        [HttpGet("Listar Pacientes")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return Ok(pacientes);
        }

        [HttpPost("Registrar Paciente")]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return Ok(paciente);
        }
        [HttpGet("BuscarPacientePorId")]
        public async Task<ActionResult<Paciente>> BuscarPacientePorId(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound("Paciente no encontrado.");
            }

            return Ok(paciente);
        }

        [HttpGet("BuscarPacientePorNombre")]
        public async Task<ActionResult<IEnumerable<Paciente>>> BuscarPacientePorNombre(string nombre)
        {
            var pacientes = await _context.Pacientes
                .Where(p => p.Nombre.Contains(nombre))
                .ToListAsync();

            if (pacientes == null || !pacientes.Any())
            {
                return NotFound("Pacientes con ese nombre no encontrados.");
            }

            return Ok(pacientes);
        }

        [HttpGet("BuscarPacientePorApellido")]
        public async Task<ActionResult<IEnumerable<Paciente>>> BuscarPacientePorApellido(string apellido)
        {
            var pacientes = await _context.Pacientes
                .Where(p => p.Apellido.Contains(apellido))
                .ToListAsync();

            if (pacientes == null || !pacientes.Any())
            {
                return NotFound("Pacientes con ese apellido no encontrados.");
            }

            return Ok(pacientes);
        }
        [HttpPut("EditarPaciente")]
        public async Task<ActionResult<Paciente>> PutPaciente(int id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest("El ID del paciente no coincide.");
            }

            var pacienteExistente = await _context.Pacientes.FindAsync(id);
            if (pacienteExistente == null)
            {
                return NotFound("Paciente no encontrado.");
            }

            pacienteExistente.Nombre = paciente.Nombre;
            pacienteExistente.Apellido = paciente.Apellido;
            pacienteExistente.Telefono = paciente.Telefono;
            pacienteExistente.Direccion = paciente.Direccion;

            await _context.SaveChangesAsync();

            return Ok("Paciente actualizado con éxito.");
        }

        [HttpDelete("EliminarPaciente")]
        public async Task<ActionResult> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound("Paciente no encontrado.");
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return Ok("Paciente eliminado con éxito.");
        }

    }
}
