using Actividad2_API_A2.Data;
using Actividad2_API_A2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_API_A2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropuestaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PropuestaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Propuesta>>> Get()
        {
            var propuestas = await _context.Propuestas.ToListAsync();
            return Ok(propuestas);
        }

        [HttpPost("Insertar")]
        public async Task<ActionResult<Propuesta>> Post(Propuesta propuesta)
        {
            var idAsociado = await _context.Asociados.FindAsync(propuesta.IdAsociado);
            propuesta.Asociado = idAsociado;

            var idOferta = await _context.OfertasLaborales.FindAsync(propuesta.IdPropuesta);
            propuesta.OfertaLaboral = idOferta;

            _context.Propuestas.Add(propuesta);
            await _context.SaveChangesAsync();
            return Ok(propuesta);
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<Propuesta>>> Buscar(int id)
        {
            var propuestas = await _context.Propuestas.FindAsync(id);
            if (propuestas == null)
            {
                return NotFound("Propuesta no encontrada");
            }

            return Ok(propuestas);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Propuesta>> Put(Propuesta propuesta, int id)
        {
            var existeId = await _context.Propuestas.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }

            var asociado = await _context.Asociados.FindAsync(propuesta.IdAsociado);
            if (asociado == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }

            var oferta = await _context.OfertasLaborales.FindAsync(propuesta.IdOferta);
            if (oferta == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }

            existeId.ArchivoPropuesta = propuesta.ArchivoPropuesta;
            existeId.FechaEnvio = propuesta.FechaEnvio;
            existeId.Estado = propuesta.Estado;
            existeId.IdAsociado = propuesta.IdAsociado;
            existeId.IdOferta = propuesta.IdOferta;

            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
    }
}
