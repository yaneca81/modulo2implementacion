using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleMedicina.Data;
using TeleMedicina.Models;

namespace TeleMedicina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        private readonly DataTelemedicina _context;

        public TratamientoController(DataTelemedicina context)
        {
            _context = context;
        }

        // GET: api/Tratamiento/Listar
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Tratamiento>>> GetTratamientos()
        {
            var tratamientos = await _context.Tratamientos
                .Include(t => t.HistorialMedico) 
                .ToListAsync();
            return Ok(tratamientos);
        }

        // POST: api/Tratamiento/Registrar
        [HttpPost("Registrar")]
        public async Task<ActionResult> PostTratamiento(Tratamiento tratamiento)
        {
            if (_context.Tratamientos == null)
            {
                return Problem("Entity set 'DataPractica.Tratamientos' is null.");
            }

            
            var historialMedico = await _context.HistorialesMedicos.FindAsync(tratamiento.IdHistorial);
            if (historialMedico == null)
            {
                return BadRequest("El historial médico asociado no existe.");
            }

     
            tratamiento.HistorialMedico = historialMedico;

            _context.Tratamientos.Add(tratamiento);
            await _context.SaveChangesAsync();

            return Ok("Tratamiento registrado correctamente.");
        }

        // GET: api/Tratamiento/BuscarId
        [HttpGet("BuscarId/{id}")]
        public async Task<ActionResult<Tratamiento>> GetTratamientoId(int id)
        {
            var tratamiento = await _context.Tratamientos
                .Include(t => t.HistorialMedico) 
                .FirstOrDefaultAsync(t => t.IdTratamiento == id);

            if (tratamiento == null)
            {
                return NotFound("Tratamiento no encontrado.");
            }

            return Ok(tratamiento);
        }

        // PUT: api/Tratamiento/Modificar
        [HttpPut("Modificar/{id}")]
        public async Task<ActionResult> PutTratamiento(Tratamiento tratamiento, int id)
        {
            var existeTratamiento = await _context.Tratamientos.FindAsync(id);
            if (existeTratamiento == null)
            {
                return NotFound("Tratamiento no encontrado.");
            }

          
            var historialMedico = await _context.HistorialesMedicos.FindAsync(tratamiento.IdHistorial);
            if (historialMedico == null)
            {
                return BadRequest("El historial médico asociado no existe.");
            }

            
            existeTratamiento.NombreMedicamento = tratamiento.NombreMedicamento;
            existeTratamiento.Dosis = tratamiento.Dosis;
            existeTratamiento.Frecuencia = tratamiento.Frecuencia;
            existeTratamiento.Duracion = tratamiento.Duracion;
            existeTratamiento.IdHistorial = tratamiento.IdHistorial;

            await _context.SaveChangesAsync();
            return Ok("Tratamiento modificado correctamente.");
        }
    }


}
