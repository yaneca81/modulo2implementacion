using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteController : ControllerBase
    {
        private readonly DataConection _context;

        public ExpedienteController(DataConection context)
        {
            _context = context;
        }

        // GET: api/Expediente
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Expediente>>> GetExpedientes()
        {
            return await _context.ExpedientesMedicos
                .Include(e => e.Paciente)
                .ToListAsync();
        }

        // GET: api/Expediente/5
        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<Expediente>> GetExpediente(int id)
        {
            var expediente = await _context.ExpedientesMedicos
                .Include(e => e.Paciente)
                .FirstOrDefaultAsync(e => e.ExpedienteMedicoId == id);

            if (expediente == null)
            {
                return NotFound("Expediente no encontrado");
            }

            return Ok(expediente);
        }

        // POST: api/Expediente
        [HttpPost("Agregar")]
        public async Task<ActionResult<Expediente>> PostExpediente(Expediente expediente)
        {
            try
            {
                _context.ExpedientesMedicos.Add(expediente);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetExpediente), new { id = expediente.ExpedienteMedicoId }, expediente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el expediente: {ex.Message}");
            }
        }

        // PUT: api/Expediente/5
        [HttpPut("Modificar/{id}")]
        public async Task<IActionResult> PutExpediente(int id, Expediente expediente)
        {
            if (id != expediente.ExpedienteMedicoId)
            {
                return BadRequest("El ID no coincide");
            }

            _context.Entry(expediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Expediente actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ExpedientesMedicos.Any(e => e.ExpedienteMedicoId == id))
                {
                    return NotFound("Expediente no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Expediente/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteExpediente(int id)
        {
            var expediente = await _context.ExpedientesMedicos.FindAsync(id);
            if (expediente == null)
            {
                return NotFound("Expediente no encontrado");
            }

            _context.ExpedientesMedicos.Remove(expediente);
            await _context.SaveChangesAsync();

            return Ok("Expediente eliminado correctamente");
        }
    }
}
