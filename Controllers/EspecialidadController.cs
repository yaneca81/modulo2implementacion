using Actividad2.Data;
using Actividad2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly DataPractica _context;
        public EspecialidadController(DataPractica context)
        {
            _context = context;
        }
        [HttpGet("Listar Especialidad")]
        public async Task<ActionResult<IEnumerable<Especialidad>>> GetEspecialidad()
        {
            var especialidad = await _context.Especialidades.ToListAsync();
            return Ok(especialidad);
        }
        [HttpPost("Registrar Especialidad")]
        public async Task<ActionResult<Especialidad>> Post(Especialidad especialidad)
        {
            var espe = _context.Especialidades.Add(especialidad);
            await _context.SaveChangesAsync();
            return Ok("REGISTRADO");

        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Especialidad>> Put(Especialidad especialidad, int id)
        {
            var existeId = await _context.Especialidades.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }
            existeId.Nombre = especialidad.Nombre;
            existeId.Descripcion = especialidad.Descripcion;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
    }
}
