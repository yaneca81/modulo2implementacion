using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermeroController : ControllerBase
    {
        private readonly DataConection _context;

        public EnfermeroController(DataConection context)
        {
            _context = context;
        }

        // GET: api/Enfermero
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Enfermero>>> GetEnfermeros()
        {
            return await _context.Enfermeros.ToListAsync();
        }

        // GET: api/Enfermero/5
        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<Enfermero>> GetEnfermero(int id)
        {
            var enfermero = await _context.Enfermeros.FindAsync(id);

            if (enfermero == null)
            {
                return NotFound("Enfermero no encontrado");
            }

            return Ok(enfermero);
        }

        // POST: api/Enfermero
        [HttpPost("Agregar")]
        public async Task<ActionResult<Enfermero>> PostEnfermero(Enfermero enfermero)
        {
            try
            {
                _context.Enfermeros.Add(enfermero);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEnfermero), new { id = enfermero.EnfermeroId }, enfermero);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el enfermero: {ex.Message}");
            }
        }

        // PUT: api/Enfermero/5
        [HttpPut("Modificar/{id}")]
        public async Task<IActionResult> PutEnfermero(int id, Enfermero enfermero)
        {
            if (id != enfermero.EnfermeroId)
            {
                return BadRequest("El ID no coincide");
            }

            _context.Entry(enfermero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Enfermero actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Enfermeros.Any(e => e.EnfermeroId == id))
                {
                    return NotFound("Enfermero no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Enfermero/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteEnfermero(int id)
        {
            var enfermero = await _context.Enfermeros.FindAsync(id);
            if (enfermero == null)
            {
                return NotFound("Enfermero no encontrado");
            }

            _context.Enfermeros.Remove(enfermero);
            await _context.SaveChangesAsync();

            return Ok("Enfermero eliminado correctamente");
        }
    }
}
