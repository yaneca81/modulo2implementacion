using Actividad2_API_A2.Data;
using Actividad2_API_A2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_API_A2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsociadoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AsociadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Asociado>>> Get()
        {
            var asociados = await _context.Asociados.ToListAsync();
            return Ok(asociados);
        }

        [HttpPost("Insertar")]
        public async Task<ActionResult<Asociado>> Post(Asociado asociado)
        {
            _context.Asociados.Add(asociado);
            await _context.SaveChangesAsync();
            return Ok(asociado);
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<Asociado>>> Buscar(int id)
        {
            var asociados = await _context.Asociados.FindAsync(id);
            if (asociados == null)
            {
                return NotFound("Asociado no encontrado");
            }

            return Ok(asociados);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Asociado>> Put(Asociado asociado, int id)
        {
            var existeId = await _context.Asociados.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }

            existeId.Nombre = asociado.Nombre;
            existeId.Apellido = asociado.Apellido;
            existeId.Email = asociado.Email;
            existeId.Telefono = asociado.Telefono;
            existeId.Direccion = asociado.Direccion;

            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
    }
}
