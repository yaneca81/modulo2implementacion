using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DataConection _context;

        public MedicoController(DataConection context)
        {
            _context = context;
        }

        // GET: api/Medico
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            return await _context.Medicos.ToListAsync();
        }

        // GET: api/Medico/5
        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<Medico>> GetMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
            {
                return NotFound("Médico no encontrado");
            }

            return Ok(medico);
        }

        // POST: api/Medico
        [HttpPost("Agregar")]
        public async Task<ActionResult<Medico>> PostMedico(Medico medico)
        {
            try
            {
                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMedico), new { id = medico.MedicoId }, medico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el médico: {ex.Message}");
            }
        }

        // PUT: api/Medico/5
        [HttpPut("Modificar/{id}")]
        public async Task<IActionResult> PutMedico(int id, Medico medico)
        {
            if (id != medico.MedicoId)
            {
                return BadRequest("El ID no coincide");
            }

            _context.Entry(medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Médico actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Medicos.Any(m => m.MedicoId == id))
                {
                    return NotFound("Médico no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Medico/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound("Médico no encontrado");
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

            return Ok("Médico eliminado correctamente");
        }
    }
}
