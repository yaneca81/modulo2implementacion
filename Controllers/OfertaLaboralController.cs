using Actividad2_API_A2.Data;
using Actividad2_API_A2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_API_A2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaLaboralController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OfertaLaboralController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<OfertaLaboral>>> Get()
        {
            var ofertas = await _context.OfertasLaborales.ToListAsync();
            return Ok(ofertas);
        }

        [HttpPost("Insertar")]
        public async Task<ActionResult<OfertaLaboral>> Post(OfertaLaboral ofertaLaboral)
        {
            _context.OfertasLaborales.Add(ofertaLaboral);
            await _context.SaveChangesAsync();
            return Ok(ofertaLaboral);
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<OfertaLaboral>>> Buscar(int id)
        {
            var ofertas = await _context.OfertasLaborales.FindAsync(id);
            if (ofertas == null)
            {
                return NotFound("Oferta no encontrada");
            }

            return Ok(ofertas);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<OfertaLaboral>> Put(OfertaLaboral ofertaLaboral, int id)
        {
            var existeId = await _context.OfertasLaborales.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }

            existeId.Titulo = ofertaLaboral.Titulo;
            existeId.Descripcion = ofertaLaboral.Descripcion;
            existeId.Requisitos = ofertaLaboral.Requisitos;
            existeId.FechaPublicacion = ofertaLaboral.FechaPublicacion;
            existeId.FechaLimite = ofertaLaboral.FechaLimite;

            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
    }
}
