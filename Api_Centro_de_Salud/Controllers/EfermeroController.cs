using Api_Centro_de_Salud.Data;
using Api_Centro_de_Salud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Centro_de_Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfermeroController : ControllerBase
    {
        private readonly ConexionDB _context;
        public EfermeroController(ConexionDB context)
        {
            _context = context;
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Enfermero>>> GetEnfermero()
        {
            var enfermeros = await _context.Enfermero.ToListAsync();
            return Ok(enfermeros);
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Enfermero>> Post(Enfermero enfermero)
        {
            var res = await _context.Enfermero.AddAsync(enfermero);
            await _context.SaveChangesAsync();
            return Ok("Se ha registrado el enfermero");
        }
        [HttpGet("BuscarEnfermero")]
        public async Task<ActionResult<IEnumerable<Enfermero>>> GetEnfermero(int id)
        {
            var enfermero = await _context.Enfermero.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (enfermero == null)
            {
                return NotFound();
            }
            return Ok(enfermero);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Enfermero>> Put(Enfermero enfermero, int id)
        {
            var existId = await _context.Enfermero.FindAsync(id);
            if (existId == null)
            {
                return NotFound("No encontrado");
            }

            existId.Nombres = enfermero.Nombres;
            existId.Apellidos = enfermero.Apellidos;
            existId.FechaIngreso = enfermero.FechaIngreso;
            existId.Telefono = enfermero.Telefono;
            existId.Correo = enfermero.Correo;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
    }
}
