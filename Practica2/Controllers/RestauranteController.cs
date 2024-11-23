using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly DataPractica _context;
        public RestauranteController(DataPractica context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Restaurante>> Post(Restaurante restaurante)
        {
            var restaurantes = _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();
            return Ok("Registrado");
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetCliente()
        {
            var restaurantes = await _context.Restaurantes.ToListAsync();
            return Ok(restaurantes);
        }
        [HttpGet("Buscar por Nombre")]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurante(string nombre)
        {
            var restaurante = await _context.Restaurantes.FirstOrDefaultAsync(t => t.Nombre == nombre);
            if(restaurante == null)
            {
                return NotFound();
            }
            return Ok(restaurante);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Restaurante>> PutRestaurate(Restaurante restaurante, int id)
        {
            var exiteId = await _context.Restaurantes.FindAsync(id);
            if (exiteId == null)
            {
                return NotFound("No encretrado");
            }
            exiteId.Nombre = restaurante.Nombre;
            exiteId.Direccion = restaurante.Direccion;
            exiteId.Telefono = restaurante.Telefono;
            await _context.SaveChangesAsync();
            return Ok("Datos Modificados");
        }
    }
}
