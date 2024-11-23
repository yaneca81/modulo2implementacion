using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly DataPractica _context;
        public PagoController(DataPractica context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult> Post(Pago pago)
        {
            var pedido = await _context.Pedidos.FindAsync(pago.IdPedido);
            if (pedido == null)
            {
                return BadRequest("El pedido asociado no existe.");
            }

            pago.Pedido = pedido;
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
            return Ok("Pago registrado exitosamente.");
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Pago>>>Get()
        {
            var habitacion = await _context.Pagos.ToArrayAsync();
            return Ok(habitacion);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult> Put(Pago pago, int id)
        {
            var existePago = await _context.Pagos.FindAsync(id);
            if (existePago == null)
            {
                return NotFound("El pago no fue encontrado.");
            }
            var pedido = await _context.Pedidos.FindAsync(pago.IdPedido);
            if (pedido == null)
            {
                return BadRequest("El pedido asociado no existe.");
            }
            existePago.IdPedido = pago.IdPedido;
            existePago.Metodo_Pago = pago.Metodo_Pago;
            existePago.Estado = pago.Estado;
            existePago.Fecha = pago.Fecha;
            await _context.SaveChangesAsync();
            return Ok("Pago modificado exitosamente.");
        }
        [HttpGet("BuscarPorId")]
        public async Task<ActionResult<Pago>> GetPago(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
            {
                return NotFound("El pago no fue encontrado.");
            }

            return Ok(pago);
        }
    }
}
