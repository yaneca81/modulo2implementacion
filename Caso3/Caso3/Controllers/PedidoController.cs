using Caso3.Data;
using Caso3.DTOs;
using Caso3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caso3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public PedidoController(RestauranteDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> GetPedidos()
        {
            return await _context.Pedidos
                .Select(p => new PedidoDto
                {
                    PedidoId = p.PedidoId,
                    UsuarioId = p.UsuarioId,
                    RestauranteId = p.RestauranteId,
                    FechaPedido = p.FechaPedido,
                    Total = p.Total,
                    Estado = p.Estado
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDto>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos
                .Select(p => new PedidoDto
                {
                    PedidoId = p.PedidoId,
                    UsuarioId = p.UsuarioId,
                    RestauranteId = p.RestauranteId,
                    FechaPedido = p.FechaPedido,
                    Total = p.Total,
                    Estado = p.Estado
                })
                .FirstOrDefaultAsync(p => p.PedidoId == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(PedidoDto pedidoDto)
        {
            var pedido = new Pedido
            {
                UsuarioId = pedidoDto.UsuarioId,
                RestauranteId = pedidoDto.RestauranteId,
                FechaPedido = pedidoDto.FechaPedido,
                Total = pedidoDto.Total,
                Estado = pedidoDto.Estado
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedido), new { id = pedido.PedidoId }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, PedidoDto pedidoDto)
        {
            if (id != pedidoDto.PedidoId)
            {
                return BadRequest();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.UsuarioId = pedidoDto.UsuarioId;
            pedido.RestauranteId = pedidoDto.RestauranteId;
            pedido.FechaPedido = pedidoDto.FechaPedido;
            pedido.Total = pedidoDto.Total;
            pedido.Estado = pedidoDto.Estado;

            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
