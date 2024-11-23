using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Modelos;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DataPractica _context;
        public MedicoController(DataPractica context)
        {
            _context = context;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<Medico>> Post(Medico medico)
        {
            var medi = _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return Ok("Registrado");
        }

        [HttpGet("Listar Medico")]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedico()
        {
            var medicos = await _context.Medicos.ToListAsync();
            return Ok(medicos);
        }

        [HttpGet("Buscar Medico")]
        public async Task<ActionResult<IEnumerable<Medico>>> BuscarMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound("Medico no encontrado.");
            }

            return Ok(medico);
        }

        [HttpGet("Buscar Medico por especialidad")]
        public async Task<ActionResult<IEnumerable<Medico>>> BuscarMedicoPorEspecialidad(string especialidad)
        {
            var medico = await _context.Medicos.FirstOrDefaultAsync(c => c.Especialidad == especialidad);
            if (medico == null)
            {
                return NotFound("habitacio no encontrado.");
            }

            return Ok(medico);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Medico>> Put(Medico medico, int id)
        {
            var exiteId = await _context.Medicos.FindAsync(id);
            if (exiteId == null)
            {
                return NotFound("No encontrado");
            }
            exiteId.Nombre = medico.Nombre;
            exiteId.Apellido = medico.Apellido;
            exiteId.Especialidad = medico.Especialidad;
            exiteId.Telefono = medico.Telefono;
            exiteId.Correo = medico.Correo;
            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
        [HttpDelete("EliminarMedico")]
        public async Task<ActionResult> DeleteMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
            {
                return NotFound("Medico no encontrado.");
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

            return Ok("Medico eliminado con éxito.");
        }
    }
}
