using Api_Centro_de_Salud.Data;
using Api_Centro_de_Salud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Centro_de_Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly ConexionDB _context;
        public MedicoController(ConexionDB context)
        {
            _context = context;
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedico()
        {
            var medicos = await _context.Medico.ToListAsync();
            return Ok(medicos);
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Medico>> Post(Medico medico)
        {
            var res = await _context.Medico.AddAsync(medico);
            await _context.SaveChangesAsync();
            return Ok("Se ha registrado el medico");
        }
        [HttpGet("BuscarMedico")]
        public async Task<ActionResult<IEnumerable<Medico>>> Get(int id)
        {
            var medico = await _context.Medico.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Medico>> Put(Medico medico, int id)
        {
            var existId = await _context.Medico.FindAsync(id);
            if (existId == null)
            {
                return NotFound("No encontrado");
            }

            existId.Nombres = medico.Nombres;
            existId.Apellidos = medico.Apellidos;
            existId.FechaIngreso = medico.FechaIngreso;
            existId.Telefono = medico.Telefono;
            existId.Correo = medico.Correo;
            existId.Especialidad = medico.Especialidad;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
    }
}
