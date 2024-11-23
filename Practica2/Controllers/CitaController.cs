using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly DataConection _context;
        public CitaController(DataConection context)
        {
            _context = context;
        }

        // GET: api/Cita
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            return await _context.CitasMedicas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .ToListAsync();
        }

        // GET: api/Cita/5
        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var cita = await _context.CitasMedicas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(c => c.CitaId == id);

            if (cita == null)
            {
                return NotFound("Cita no encontrada");
            }

            return Ok(cita);
        }

        // POST: api/Cita
        [HttpPost("Agregar")]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            try
            {
                _context.CitasMedicas.Add(cita);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCita), new { id = cita.CitaId }, cita);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la cita: {ex.Message}");
            }
        }

        // PUT: api/Cita/5
        [HttpPut("Modificar/{id}")]
        public async Task<IActionResult> PutCita(int id, Cita cita)
        {
            if (id != cita.CitaId)
            {
                return BadRequest("El ID no coincide");
            }

            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Cita actualizada correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CitasMedicas.Any(e => e.CitaId == id))
                {
                    return NotFound("Cita no encontrada");
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Cita/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var cita = await _context.CitasMedicas.FindAsync(id);
            if (cita == null)
            {
                return NotFound("Cita no encontrada");
            }

            _context.CitasMedicas.Remove(cita);
            await _context.SaveChangesAsync();

            return Ok("Cita eliminada correctamente");
        }
    }
}
