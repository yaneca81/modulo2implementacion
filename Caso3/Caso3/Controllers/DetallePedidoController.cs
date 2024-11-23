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
    public class DetallePedidoController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public DetallePedidoController(RestauranteDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedidoDto>>> GetDetallesPedidos()
        {
            return await _context.DetallesPedido
                .Select(d => new DetallePedidoDto
                {
                    DetallePedidoId = d.DetallePedidoId,
                    PedidoId = d.PedidoId,
                    MenuId = d.MenuId,
                    Cantidad = d.Cantidad,
                    Subtotal = d.Subtotal
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedidoDto>> GetDetallePedido(int id)
        {
            var detallePedido = await _context.DetallesPedido
                .Select(d => new DetallePedidoDto
                {
                    DetallePedidoId = d.DetallePedidoId,
                    PedidoId = d.PedidoId,
                    MenuId = d.MenuId,
                    Cantidad = d.Cantidad,
                    Subtotal = d.Subtotal
                })
                .FirstOrDefaultAsync(d => d.DetallePedidoId == id);

            if (detallePedido == null)
            {
                return NotFound();
            }

            return detallePedido;
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedidoDto detallePedidoDto)
        {
            var detallePedido = new DetallePedido
            {
                PedidoId = detallePedidoDto.PedidoId,
                MenuId = detallePedidoDto.MenuId,
                Cantidad = detallePedidoDto.Cantidad,
                Subtotal = detallePedidoDto.Subtotal
            };

            _context.DetallesPedido.Add(detallePedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetallePedido), new { id = detallePedido.DetallePedidoId }, detallePedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePedido(int id, DetallePedidoDto detallePedidoDto)
        {
            if (id != detallePedidoDto.DetallePedidoId)
            {
                return BadRequest();
            }

            var detallePedido = await _context.DetallesPedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            detallePedido.PedidoId = detallePedidoDto.PedidoId;
            detallePedido.MenuId = detallePedidoDto.MenuId;
            detallePedido.Cantidad = detallePedidoDto.Cantidad;
            detallePedido.Subtotal = detallePedidoDto.Subtotal;

            _context.Entry(detallePedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            var detallePedido = await _context.DetallesPedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            _context.DetallesPedido.Remove(detallePedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
