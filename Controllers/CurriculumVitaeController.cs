using Actividad2_API_A2.Data;
using Actividad2_API_A2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_API_A2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumVitaeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurriculumVitaeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<CurriculumVitae>>> Get()
        {
            var curriculum = await _context.CurriculumVitaes.ToListAsync();
            return Ok(curriculum);
        }

        [HttpPost("Insertar")]
        public async Task<ActionResult<CurriculumVitae>> Post(CurriculumVitae curriculumVitae)
        {
            var idAsociado = await _context.Asociados.FindAsync(curriculumVitae.IdAsociado);
            curriculumVitae.Asociado = idAsociado;

            _context.CurriculumVitaes.Add(curriculumVitae);
            await _context.SaveChangesAsync();
            return Ok(curriculumVitae);
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<CurriculumVitae>>> Buscar(int id)
        {
            var curriculum = await _context.CurriculumVitaes.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound("Curriculum no encontrado");
            }

            return Ok(curriculum);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<CurriculumVitae>> Put(CurriculumVitae curriculumVitae, int id)
        {
            var existeId = await _context.CurriculumVitaes.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }

            var asociado = await _context.Asociados.FindAsync(curriculumVitae.IdAsociado);
            if (asociado == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }

            existeId.ArchivoPdf = curriculumVitae.ArchivoPdf;
            existeId.FechaSubida = curriculumVitae.FechaSubida;
            existeId.IdAsociado = curriculumVitae.IdAsociado;

            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
    }
}
