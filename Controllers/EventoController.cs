using Actividad2_API_A2.Data;
using Actividad2_API_A2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_API_A2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Evento>>> Get()
        {
            var eventos = await _context.Eventos.ToListAsync();
            return Ok(eventos);
        }

        [HttpPost("Insertar")]
        public async Task<ActionResult<Evento>> Post(Evento evento)
        {
            var idAsociado = await _context.Asociados.FindAsync(evento.IdAsociado);
            evento.Asociado = idAsociado;

            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<Evento>>> Buscar(int id)
        {
            var eventos = await _context.Eventos.FindAsync(id);
            if (eventos == null)
            {
                return NotFound("Evento no encontrado");
            }

            return Ok(eventos);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Evento>> Put(Evento evento, int id)
        {
            var existeId = await _context.Eventos.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }

            var asociado = await _context.Asociados.FindAsync(evento.IdAsociado);
            if (asociado == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }

            existeId.NombreEvento = evento.NombreEvento;
            existeId.Fecha = evento.Fecha;
            existeId.Ubicacion = evento.Ubicacion;
            existeId.Descripcion = evento.Descripcion;
            existeId.IdAsociado = evento.IdAsociado;

            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
    }
}
