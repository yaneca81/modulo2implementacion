using Actividad2.Data;
using Actividad2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionVideoLlamadaController : ControllerBase
    {
        //declarando la variable que va a trabjar con la conexion
        private readonly DataPractica _context;
        public SesionVideoLlamadaController(DataPractica context)
        {
            _context = context;
        }

        [HttpGet("Listar Reserva")]
        public async Task<ActionResult<IEnumerable<SesionVideoLlamada>>> GetSesion()
        {
            var sesiones = await _context.SesionVideoLlamadas.ToListAsync();
            return Ok(sesiones);
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<SesionVideoLlamada>> Post(SesionVideoLlamada sesion)
        {
            if (sesion == null)
            {
                return BadRequest("La sesion es inválida.");
            }

            var cita = await _context.Citas.FindAsync(sesion.IdCita);

            if (cita == null )
            {
                return BadRequest("Citas no encontrados.");
            }

            sesion.Cita = cita;

            _context.SesionVideoLlamadas.Add(sesion);
            await _context.SaveChangesAsync();
            return Ok("Sesion registrada");
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<SesionVideoLlamada>> Put(SesionVideoLlamada sesion, int id)
        {
            var existeId = await _context.SesionVideoLlamadas.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }
            var cita = await _context.SesionVideoLlamadas.FindAsync(sesion.IdCita);
            if (cita == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existeId.Fecha = cita.Fecha;
            existeId.HoraInicio = cita.HoraInicio;
            existeId.HoraFin = cita.HoraFin;
            existeId.Grabaciones = cita.Grabaciones;
            existeId.IdCita = cita.IdCita;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }

    }
}
