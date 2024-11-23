using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatilloController : ControllerBase
    {
        private readonly DataPractica _context;
        public PlatilloController(DataPractica context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Platillo>> Post(Platillo reserva)
        {
            var id = await _context.Menus.FindAsync(reserva.IdMenu);
            reserva.Menu = id;
            var rese = _context.Platillos.Add(reserva);
            await _context.SaveChangesAsync();
            return Ok("Platillos Registrados");
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Platillo>>> Get()
        {
            var platillos = await _context.Platillos.ToListAsync();
            return Ok(platillos);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult> Put(Platillo platillo, int id)
        {
            var existePlatillo = await _context.Platillos.FindAsync(id);
            if (existePlatillo == null)
            {
                return NotFound("El platillo no fue encontrado.");
            }
            var menu = await _context.Menus.FindAsync(platillo.IdMenu);
            if (menu == null)
            {
                return BadRequest("El menú asociado no existe.");
            }
            existePlatillo.IdMenu = platillo.IdMenu;
            existePlatillo.Nombre = platillo.Nombre;
            existePlatillo.Descripcion = platillo.Descripcion;
            existePlatillo.Precio = platillo.Precio;
            existePlatillo.Cantidad = platillo.Cantidad;
            await _context.SaveChangesAsync();
            return Ok("Platillo modificado exitosamente.");
        }
        [HttpGet("BuscarPorId")]
        public async Task<ActionResult<Platillo>> GetPlatillo(int id)
        {
            var platillo = await _context.Platillos.Include(p => p.Menu).FirstOrDefaultAsync(p => p.Id == id);
            if (platillo == null)
            {
                return NotFound("El platillo no fue encontrado.");
            }
            return Ok(platillo);
        }
    }
}
