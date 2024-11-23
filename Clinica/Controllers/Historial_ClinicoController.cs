using Clinia.Data;
using Clinia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Historial_ClinicoController : ControllerBase
    {
        private readonly DataClinica _context;

        public Historial_ClinicoController(DataClinica context)
        {
            _context = context;
        }

        [HttpGet("Listar Historiales Clinicos")]
        public async Task<ActionResult<IEnumerable<Historial_clinico>>> GetHistorialesClinicos()
        {
            var historiales = await _context.Historial_Clinicos
                .Include(h => h.Paciente)
                .ToListAsync();

            return Ok(historiales);
        }
        [HttpGet("BuscarHistorialClinico")]
        public async Task<ActionResult<Historial_clinico>> BuscarHistorialClinico(int id)
        {
            var historial = await _context.Historial_Clinicos.FindAsync(id);

            if (historial == null)
            {
                return NotFound("Historial clínico no encontrado.");
            }

            return Ok(historial);
        }

        //[HttpPost("AgregarHistorialClinico")]
        //public async Task<ActionResult<Historial_clinico>> PostHistorialClinico(Historial_clinico historial)
        //{
        //    if (historial == null)
        //    {
        //        return BadRequest("El historial clínico es inválido.");
        //    }

        //    _context.Historial_Clinicos.Add(historial);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("BuscarHistorialClinico", new { id = historial.Id }, historial);
        //}
        [HttpPost("AgregarHistorialClinico")]
        public async Task<ActionResult<Historial_clinico>> PostHistorialClinico(Historial_clinico historial)
        {
            if (historial == null)
            {
                return BadRequest("El historial clínico es inválido.");
            }

            var paciente = await _context.Pacientes.FindAsync(historial.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("Paciente no encontrado.");
            }

            historial.Paciente = paciente;

            _context.Historial_Clinicos.Add(historial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("BuscarHistorialClinico", new { id = historial.Id }, historial);
        }

        //[HttpPut("EditarHistorialClinico")]
        //public async Task<ActionResult<Historial_clinico>> PutHistorialClinico(int id, Historial_clinico historial)
        //{
        //    if (id != historial.Id)
        //    {
        //        return BadRequest("El ID del historial clínico no coincide.");
        //    }

        //    var historialExistente = await _context.Historial_Clinicos.FindAsync(id);
        //    if (historialExistente == null)
        //    {
        //        return NotFound("Historial clínico no encontrado.");
        //    }

        //    historialExistente.Observaciones = historial.Observaciones;
        //    historialExistente.FechaRegistro = historial.FechaRegistro;
        //    historialExistente.IdPaciente = historial.IdPaciente;

        //    await _context.SaveChangesAsync();

        //    return Ok("Historial clínico actualizado con éxito.");
        //}
        [HttpPut("EditarHistorialClinico")]
        public async Task<ActionResult<Historial_clinico>> PutHistorialClinico(int id, Historial_clinico historial)
        {
            if (id != historial.Id)
            {
                return BadRequest("El ID del historial clínico no coincide.");
            }

            var historialExistente = await _context.Historial_Clinicos.Include(h => h.Paciente).FirstOrDefaultAsync(h => h.Id == id);
            if (historialExistente == null)
            {
                return NotFound("Historial clínico no encontrado.");
            }

            var paciente = await _context.Pacientes.FindAsync(historial.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("Paciente no encontrado.");
            }

            historialExistente.Observaciones = historial.Observaciones;
            historialExistente.FechaRegistro = historial.FechaRegistro;
            historialExistente.Paciente = paciente;

            await _context.SaveChangesAsync();

            return Ok("Historial clínico actualizado con éxito.");
        }

        [HttpDelete("EliminarHistorialClinico")]
        public async Task<ActionResult> DeleteHistorialClinico(int id)
        {
            var historial = await _context.Historial_Clinicos.FindAsync(id);

            if (historial == null)
            {
                return NotFound("Historial clínico no encontrado.");
            }

            _context.Historial_Clinicos.Remove(historial);
            await _context.SaveChangesAsync();

            return Ok("Historial clínico eliminado con éxito.");
        }
    }
}
