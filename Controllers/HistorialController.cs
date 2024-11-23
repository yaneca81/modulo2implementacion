using Actividad2.Data;
using Actividad2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        //declarando la variable que va a trabjar con la conexion
        private readonly DataPractica _context;
        public HistorialController(DataPractica context)
        {
            _context = context;
        }
        [HttpGet("Listar Historial")]
        public async Task<ActionResult<IEnumerable<Historial>>> GetHistorial()
        {
            var historial = await _context.Historiales.ToListAsync();
            return Ok(historial);
        }
        [HttpPost("Registrar Historial")]
        public async Task<ActionResult<Cita>> PostHistorial(Historial historial)
        {
            if (historial == null)
            {
                return BadRequest("La cita es inválida.");
            }

            var paciente = await _context.Pacientes.FindAsync(historial.IdPaciente);

            if (paciente == null )
            {
                return BadRequest("Paciente no encontrados.");
            }

            historial.Paciente = paciente;

            _context.Historiales.Add(historial);
            await _context.SaveChangesAsync();
            return Ok("Historial registrada");
            
        }
        /*[HttpPost("Registrar Historial")]
        public async Task<ActionResult<Historial>> Post(Historial historial)
        {

            var id = await _context.Pacientes.FindAsync(historial.IdPaciente);
            historial.Paciente = id;

            var rese = _context.Historiales.Add(historial);
            await _context.SaveChangesAsync();
            return Ok("Reserva registrada");

        }*/
        [HttpPut("Modificar")]
        public async Task<ActionResult<Historial>> Put(Historial historial, int id)
        {
            var existeId = await _context.Historiales.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }
            var paciente = await _context.Historiales.FindAsync(historial.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existeId.Fecha = historial.Fecha;
            existeId.Estado = historial.Estado;
            existeId.IdPaciente = historial.IdPaciente;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
    }
}
