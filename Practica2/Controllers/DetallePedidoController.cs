using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly DataPractica _context;
        public DetallePedidoController(DataPractica context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult> Post(Detalle_Pedido detallePedido)
        {
            var pedido = await _context.Pedidos.FindAsync(detallePedido.IdPedido);
            if (pedido == null)
            {
                return BadRequest("El pedido asociado no existe.");
            }
            var platillo = await _context.Platillos.FindAsync(detallePedido.IdPlatillo);
            if (platillo == null)
            {
                return BadRequest("El platillo asociado no existe.");
            }
            detallePedido.Pedido = pedido;
            detallePedido.Platillo = platillo;
            _context.DetallePedidos.Add(detallePedido);
            await _context.SaveChangesAsync();
            return Ok("Detalle de pedido registrado exitosamente.");
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Detalle_Pedido>>> Get()
        {
            var platillos = await _context.DetallePedidos.ToListAsync();
            return Ok(platillos);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult> Put(Detalle_Pedido detallePedido, int id)
        {
            var existeDetalle = await _context.DetallePedidos.FindAsync(id);
            if (existeDetalle == null)
            {
                return NotFound("El detalle de pedido no fue encontrado.");
            }
            var pedido = await _context.Pedidos.FindAsync(detallePedido.IdPedido);
            if (pedido == null)
            {
                return BadRequest("El pedido asociado no existe.");
            }
            var platillo = await _context.Platillos.FindAsync(detallePedido.IdPlatillo);
            if (platillo == null)
            {
                return BadRequest("El platillo asociado no existe.");
            }
            existeDetalle.IdPedido = detallePedido.IdPedido;
            existeDetalle.IdPlatillo = detallePedido.IdPlatillo;
            existeDetalle.Cantidad = detallePedido.Cantidad;
            existeDetalle.Sub_Total = detallePedido.Sub_Total;
            await _context.SaveChangesAsync();
            return Ok("Detalle de pedido modificado exitosamente.");
        }

    }
}
