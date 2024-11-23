using Caso3.Data;
using Caso3.DTOs;
using Caso3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Caso3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public RestauranteController(RestauranteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestauranteDto>>> GetRestaurantes()
        {
            return await _context.Restaurantes
                .Select(r => new RestauranteDto
                {
                    RestauranteId = r.RestauranteId,
                    Nombre = r.Nombre,
                    Direccion = r.Direccion,
                    Telefono = r.Telefono,
                    Correo = r.Correo
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestauranteDto>> GetRestaurante(int id)
        {
            var restaurante = await _context.Restaurantes
                .Select(r => new RestauranteDto
                {
                    RestauranteId = r.RestauranteId,
                    Nombre = r.Nombre,
                    Direccion = r.Direccion,
                    Telefono = r.Telefono,
                    Correo = r.Correo
                })
                .FirstOrDefaultAsync(r => r.RestauranteId == id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return restaurante;
        }

        [HttpPost]
        public async Task<ActionResult<Restaurante>> PostRestaurante(RestauranteDto restauranteDto)
        {
            var restaurante = new Restaurante
            {
                Nombre = restauranteDto.Nombre,
                Direccion = restauranteDto.Direccion,
                Telefono = restauranteDto.Telefono,
                Correo = restauranteDto.Correo
            };

            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRestaurante), new { id = restaurante.RestauranteId }, restaurante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurante(int id, RestauranteDto restauranteDto)
        {
            if (id != restauranteDto.RestauranteId)
            {
                return BadRequest();
            }

            var restaurante = await _context.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            restaurante.Nombre = restauranteDto.Nombre;
            restaurante.Direccion = restauranteDto.Direccion;
            restaurante.Telefono = restauranteDto.Telefono;
            restaurante.Correo = restauranteDto.Correo;

            _context.Entry(restaurante).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurante(int id)
        {
            var restaurante = await _context.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restaurantes.Remove(restaurante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
