using Actividad2_API_A2.Data;
using Actividad2_API_A2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_API_A2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuotaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CuotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Cuota>>> Get()
        {
            var cuotas = await _context.Cuotas.ToListAsync();
            return Ok(cuotas);
        }

        [HttpPost("Insertar")]
        public async Task<ActionResult<Cuota>> Post(Cuota cuota)
        {
            var idAsociado = await _context.Asociados.FindAsync(cuota.IdAsociado);
            cuota.Asociado = idAsociado;

            _context.Cuotas.Add(cuota);
            await _context.SaveChangesAsync();
            return Ok(cuota);
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<Cuota>>> Buscar(int id)
        {
            var cuotas = await _context.Cuotas.FindAsync(id);
            if (cuotas == null)
            {
                return NotFound("Cuota no encontrada");
            }

            return Ok(cuotas);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Cuota>> Put(Cuota cuota, int id)
        {
            var existeId = await _context.Cuotas.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }

            var asociado = await _context.Asociados.FindAsync(cuota.IdAsociado);
            if (asociado == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }

            existeId.Monto = cuota.Monto;
            existeId.FechaPago = cuota.FechaPago;
            existeId.Estado = cuota.Estado;
            existeId.IdAsociado = cuota.IdAsociado;

            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
    }
}
