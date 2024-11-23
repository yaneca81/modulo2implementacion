using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DataConection _context;
        public PacienteController(DataConection context)
        {
            _context = context;
        }

        // GET: api/Paciente
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            return await _context.Pacientes.ToListAsync();
        }

        // GET: api/Paciente/5
        [HttpGet("Buscar {id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _context.Pacientes
                .Include(p => p.Expediente)
                .FirstOrDefaultAsync(p => p.PacienteId == id);

            if (paciente == null)
            {
                return NotFound("Paciente no encontrado");
            }

            return Ok(paciente);
        }

        // POST: api/Paciente
        [HttpPost("Agregar")]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            try
            {
                // Asegurarse de que no se está enviando un ID
                paciente.PacienteId = 0;
                // Establecer expediente a null para evitar problemas de creación
                paciente.Expediente = null;

                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPaciente), new { id = paciente.PacienteId }, paciente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el paciente: {ex.Message}");
            }
        }

        // PUT: api/Paciente/5
        [HttpPut("Modificar {id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (id != paciente.PacienteId)
            {
                return BadRequest("El ID no coincide");
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Paciente actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
                {
                    return NotFound("Paciente no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Paciente/5
        [HttpDelete("Eliminar {id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound("Paciente no encontrado");
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return Ok("Paciente eliminado correctamente");
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.PacienteId == id);
        }
    }
}