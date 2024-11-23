using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly DataPractica _context;
        public MenuController(DataPractica context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Menu>> Post(Menu reserva)
        {
            var id = await _context.Restaurantes.FindAsync(reserva.IdRestaurante);
            reserva.Restaurante = id;
            var rese = _context.Menus.Add(reserva);
            await _context.SaveChangesAsync();
            return Ok("Menu Registrado");
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Menu>>> Get()
        {
            var habitacion = await _context.Menus.ToListAsync();
            return Ok(habitacion);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Menu>> Put(Menu reserva, int id)
        {
            var existeId = await _context.Menus.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No Encontrado");
            }
            var habitacion = await _context.Menus.FindAsync(reserva.IdRestaurante);
            if (habitacion == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existeId.IdRestaurante = reserva.IdRestaurante;
            existeId.Nombre = reserva.Nombre;
            existeId.Descripcion = reserva.Descripcion;
            existeId.Estado = reserva.Estado;
            await _context.SaveChangesAsync();
            return Ok("Datos Modificados");
        }
        [HttpGet("Buscar por el Estado")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenu(string estado)
        {
            var clientes = await _context.Menus.FirstOrDefaultAsync(t => t.Estado == estado);//generalmente es para otro tipo de busqueda que no sea por id FirstOrDefaultAsync
            if (clientes == null)
            {
                return NotFound();
            }
            return Ok(clientes);
        }
    }
}
