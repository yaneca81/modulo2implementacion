using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizacionController : ControllerBase
    {
        private readonly DataConection _context;

        public HospitalizacionController(DataConection context)
        {
            _context = context;
        }

        // GET: api/Hospitalizacion
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Hospitalizacion>>> GetHospitalizaciones()
        {
            return await _context.Hospitalizaciones
                .Include(h => h.Paciente)
                .Include(h => h.Medico)
                .Include(h => h.Enfermero)
                .ToListAsync();
        }

        // GET: api/Hospitalizacion/5
        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<Hospitalizacion>> GetHospitalizacion(int id)
        {
            var hospitalizacion = await _context.Hospitalizaciones
                .Include(h => h.Paciente)
                .Include(h => h.Medico)
                .Include(h => h.Enfermero)
                .FirstOrDefaultAsync(h => h.HospitalizacionId == id);

            if (hospitalizacion == null)
            {
                return NotFound("Hospitalización no encontrada");
            }

            return Ok(hospitalizacion);
        }

        // POST: api/Hospitalizacion
        [HttpPost("Agregar")]
        public async Task<ActionResult<Hospitalizacion>> PostHospitalizacion(Hospitalizacion hospitalizacion)
        {
            try
            {
                _context.Hospitalizaciones.Add(hospitalizacion);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetHospitalizacion), new { id = hospitalizacion.HospitalizacionId }, hospitalizacion);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la hospitalización: {ex.Message}");
            }
        }

        // PUT: api/Hospitalizacion/5
        [HttpPut("Modificar/{id}")]
        public async Task<IActionResult> PutHospitalizacion(int id, Hospitalizacion hospitalizacion)
        {
            if (id != hospitalizacion.HospitalizacionId)
            {
                return BadRequest("El ID no coincide");
            }

            _context.Entry(hospitalizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Hospitalización actualizada correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Hospitalizaciones.Any(h => h.HospitalizacionId == id))
                {
                    return NotFound("Hospitalización no encontrada");
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Hospitalizacion/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteHospitalizacion(int id)
        {
            var hospitalizacion = await _context.Hospitalizaciones.FindAsync(id);
            if (hospitalizacion == null)
            {
                return NotFound("Hospitalización no encontrada");
            }

            _context.Hospitalizaciones.Remove(hospitalizacion);
            await _context.SaveChangesAsync();

            return Ok("Hospitalización eliminada correctamente");
        }
    }
}
