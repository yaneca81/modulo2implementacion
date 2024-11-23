using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly DataPractica _context;
        public PedidoController(DataPractica context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult> Post(Pedido pedido)
        {
            var usuario = await _context.Usuarios.FindAsync(pedido.IdUsuario);
            if (usuario == null)
            {
                return BadRequest("El usuario asociado no existe.");
            }
            var restaurante = await _context.Restaurantes.FindAsync(pedido.IdRestaurante);
            if (restaurante == null)
            {
                return BadRequest("El restaurante asociado no existe.");
            }
            pedido.Usuario = usuario;
            pedido.Restaurante = restaurante;
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return Ok("Pedido registrado exitosamente.");
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Pedido>>> Get()
        {
            var pedidos = await _context.Pedidos.ToListAsync();
            return Ok(pedidos);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult> Put(Pedido pedido, int id)
        {
            var existePedido = await _context.Pedidos.FindAsync(id);
            if (existePedido == null)
            {
                return NotFound("El pedido no fue encontrado.");
            }
            var usuario = await _context.Usuarios.FindAsync(pedido.IdUsuario);
            if (usuario == null)
            {
                return BadRequest("El usuario asociado no existe.");
            }
            var restaurante = await _context.Restaurantes.FindAsync(pedido.IdRestaurante);
            if (restaurante == null)
            {
                return BadRequest("El restaurante asociado no existe.");
            }
            existePedido.IdUsuario = pedido.IdUsuario;
            existePedido.IdRestaurante = pedido.IdRestaurante;
            existePedido.Estado = pedido.Estado;
            existePedido.Total = pedido.Total;
            existePedido.Fecha = pedido.Fecha;
            await _context.SaveChangesAsync();
            return Ok("Pedido modificado exitosamente.");
        }
        [HttpGet("Buscar por el Estado")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido(string estado)
        {
            var clientes = await _context.Pedidos.FirstOrDefaultAsync(t => t.Estado == estado);//generalmente es para otro tipo de busqueda que no sea por id FirstOrDefaultAsync
            if (clientes == null)
            {
                return NotFound();
            }
            return Ok(clientes);
        }
    }
}
