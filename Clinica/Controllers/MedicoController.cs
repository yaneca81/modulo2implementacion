using Clinia.Data;
using Clinia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DataClinica _context;

        public MedicoController(DataClinica context)
        {
            _context = context;
        }

        [HttpGet("Listar Medicos")]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            var medicos = await _context.Medicos.ToListAsync();
            return Ok(medicos);
        }

        [HttpPost("Registrar Medico")]
        public async Task<ActionResult<Medico>> PostMedico(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return Ok(medico);
        }
        [HttpGet("BuscarMedicoPorId")]
        public async Task<ActionResult<Medico>> BuscarMedicoPorId(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
            {
                return NotFound("Médico no encontrado.");
            }

            return Ok(medico);
        }

        [HttpGet("BuscarMedicoPorNombre")]
        public async Task<ActionResult<IEnumerable<Medico>>> BuscarMedicoPorNombre(string nombre)
        {
            var medicos = await _context.Medicos
                .Where(m => m.Nombre.Contains(nombre))
                .ToListAsync();

            if (medicos == null || !medicos.Any())
            {
                return NotFound("Médicos con ese nombre no encontrados.");
            }

            return Ok(medicos);
        }

        [HttpGet("BuscarMedicoPorApellido")]
        public async Task<ActionResult<IEnumerable<Medico>>> BuscarMedicoPorApellido(string apellido)
        {
            var medicos = await _context.Medicos
                .Where(m => m.Apellido.Contains(apellido))
                .ToListAsync();

            if (medicos == null || !medicos.Any())
            {
                return NotFound("Médicos con ese apellido no encontrados.");
            }

            return Ok(medicos);
        }
        [HttpPut("EditarMedico")]
        public async Task<ActionResult<Medico>> PutMedico(int id, Medico medico)
        {
            if (id != medico.Id)
            {
                return BadRequest("El ID del médico no coincide.");
            }

            var medicoExistente = await _context.Medicos.FindAsync(id);
            if (medicoExistente == null)
            {
                return NotFound("Médico no encontrado.");
            }

            medicoExistente.Nombre = medico.Nombre;
            medicoExistente.Apellido = medico.Apellido;
            medicoExistente.Especialidad = medico.Especialidad;

            await _context.SaveChangesAsync();

            return Ok("Médico actualizado con éxito.");
        }

        [HttpDelete("EliminarMedico")]
        public async Task<ActionResult> DeleteMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
            {
                return NotFound("Médico no encontrado.");
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

            return Ok("Médico eliminado con éxito.");
        }
    }
}
