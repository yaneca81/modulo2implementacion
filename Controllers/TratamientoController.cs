using Actividad2.Data;
using Actividad2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        //declarando la variable que va a trabjar con la conexion
        private readonly DataPractica _context;
        public TratamientoController(DataPractica context)
        {
            _context = context;
        }
        [HttpGet("Listar Tratamiento")]
        public async Task<ActionResult<IEnumerable<Tratamiento>>> GetTratamiento()
        {
            var tratamiento = await _context.Tratamientos.ToListAsync();
            return Ok(tratamiento);
        }
        [HttpPost("Registrar Tratamiento")]
        public async Task<ActionResult<Tratamiento>> Post(Tratamiento tratamiento)
        {
            if (tratamiento == null)
            {
                return BadRequest("El tratamiento es inválida.");
            }

            var historial = await _context.Historiales.FindAsync(tratamiento.IdHistorial);

            if (historial == null)
            {
                return BadRequest("Historial no encontrados.");
            }

            tratamiento.Historial = historial;

            _context.Tratamientos.Add(tratamiento);
            await _context.SaveChangesAsync();
            return Ok("Tratamiento registrada"); 
            

        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Tratamiento>> Put(Tratamiento tratamiento, int id)
        {
            var existeId = await _context.Tratamientos.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }
            var historia = await _context.Tratamientos.FindAsync(tratamiento.IdHistorial);
            if (historia == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existeId.FechaInicio = tratamiento.FechaInicio;
            existeId.FechaFin = tratamiento.FechaFin;
            existeId.PrescripcionMedicamentos = tratamiento.PrescripcionMedicamentos;
            existeId.Recomendaciones = tratamiento.Recomendaciones;
            existeId.IdHistorial = tratamiento.IdHistorial;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
        //busqueda por id
        [HttpGet("Buscar id")]
        public async Task<ActionResult<IEnumerable<Historial>>> Gethistorial(int id)
        {
            var historiales = await _context.Historiales.FindAsync(id);
            if (historiales == null)
            {
                return NotFound();
            }
            return Ok(historiales);
        }
    }
}
