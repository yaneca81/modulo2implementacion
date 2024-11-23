using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleMedicina.Data;
using TeleMedicina.Models;

namespace TeleMedicina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DataTelemedicina _context;

        public MedicoController(DataTelemedicina context)
        {
            _context = context;
        }

        // GET: api/Medico/Listar
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            var medicos = await _context.Medicos.ToListAsync();
            return Ok(medicos);
        }

        // POST: api/Medico/Registrar
        [HttpPost("Registrar")]
        public async Task<ActionResult> PostMedico(Medico medico)
        {
            if (_context.Medicos == null)
            {
                return Problem("Entity set 'DataPractica.Medicos' is null.");
            }

            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();

            return Ok("Médico registrado correctamente.");
        }

        // GET: api/Medico/BuscarId
        [HttpGet("BuscarId/{id}")]
        public async Task<ActionResult<Medico>> GetMedicoId(int id)
        {
            var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.IdMedico == id);

            if (medico == null)
            {
                return NotFound("Médico no encontrado.");
            }

            return Ok(medico);
        }

        // PUT: api/Medico/Modificar
        [HttpPut("Modificar/{id}")]
        public async Task<ActionResult> PutMedico(Medico medico, int id)
        {
            var existeMedico = await _context.Medicos.FindAsync(id);
            if (existeMedico == null)
            {
                return NotFound("Médico no encontrado.");
            }


            existeMedico.Nombre = medico.Nombre;
            existeMedico.Apellido = medico.Apellido;
            existeMedico.Especialidad = medico.Especialidad;
            existeMedico.Telefono = medico.Telefono;

            await _context.SaveChangesAsync();
            return Ok("Médico modificado correctamente.");
        }
    }

}
