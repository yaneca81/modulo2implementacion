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
    public class PagoController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public PagoController(RestauranteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagoDto>>> GetPagos()
        {
            return await _context.Pagos
                .Select(p => new PagoDto
                {
                    PagoId = p.PagoId,
                    PedidoId = p.PedidoId,
                    Monto = p.Monto,
                    MetodoPago = p.MetodoPago,
                    FechaPago = p.FechaPago
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PagoDto>> GetPago(int id)
        {
            var pago = await _context.Pagos
                .Select(p => new PagoDto
                {
                    PagoId = p.PagoId,
                    PedidoId = p.PedidoId,
                    Monto = p.Monto,
                    MetodoPago = p.MetodoPago,
                    FechaPago = p.FechaPago
                })
                .FirstOrDefaultAsync(p => p.PagoId == id);

            if (pago == null)
            {
                return NotFound();
            }

            return pago;
        }

        [HttpPost]
        public async Task<ActionResult<Pago>> PostPago(PagoDto pagoDto)
        {
            var pago = new Pago
            {
                PedidoId = pagoDto.PedidoId,
                Monto = pagoDto.Monto,
                MetodoPago = pagoDto.MetodoPago,
                FechaPago = pagoDto.FechaPago
            };

            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPago), new { id = pago.PagoId }, pago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPago(int id, PagoDto pagoDto)
        {
            if (id != pagoDto.PagoId)
            {
                return BadRequest();
            }

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            pago.PedidoId = pagoDto.PedidoId;
            pago.Monto = pagoDto.Monto;
            pago.MetodoPago = pagoDto.MetodoPago;
            pago.FechaPago = pagoDto.FechaPago;

            _context.Entry(pago).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
