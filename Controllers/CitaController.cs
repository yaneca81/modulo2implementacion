using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleMedicina.Data;
using TeleMedicina.Models;

namespace TeleMedicina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly DataTelemedicina _context;

        public CitaController(DataTelemedicina context)
        {
            _context = context;
        }

        // GET: api/Cita/Listar
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            var citas = await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .ToListAsync();
            return Ok(citas);
        }

        // POST: api/Cita/Registrar
        [HttpPost("Registrar")]
        public async Task<ActionResult> PostCita(Cita cita)
        {
            if (_context.Citas == null)
            {
                return Problem("Entity set 'DataPractica.Citas' is null.");
            }

            var paciente = await _context.Pacientes.FindAsync(cita.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El paciente asociado no existe.");
            }


            var medico = await _context.Medicos.FindAsync(cita.IdMedico);
            if (medico == null)
            {
                return BadRequest("El médico asociado no existe.");
            }


            cita.Paciente = paciente;
            cita.Medico = medico;

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return Ok("Cita registrada correctamente.");
        }

        // GET: api/Cita/BuscarId
        [HttpGet("BuscarId/{id}")]
        public async Task<ActionResult<Cita>> GetCitaId(int id)
        {
            var cita = await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(c => c.IdCita == id);

            if (cita == null)
            {
                return NotFound("Cita no encontrada.");
            }

            return Ok(cita);
        }

        // PUT: api/Cita/Modificar
        [HttpPut("Modificar/{id}")]
        public async Task<ActionResult> PutCita(Cita cita, int id)
        {
            var existeCita = await _context.Citas.FindAsync(id);
            if (existeCita == null)
            {
                return NotFound("Cita no encontrada.");
            }


            var paciente = await _context.Pacientes.FindAsync(cita.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El paciente asociado no existe.");
            }


            var medico = await _context.Medicos.FindAsync(cita.IdMedico);
            if (medico == null)
            {
                return BadRequest("El médico asociado no existe.");
            }


            existeCita.FechaHora = cita.FechaHora;
            existeCita.Estado = cita.Estado;
            existeCita.Motivo = cita.Motivo;
            existeCita.IdPaciente = cita.IdPaciente;
            existeCita.IdMedico = cita.IdMedico;

            await _context.SaveChangesAsync();
            return Ok("Cita modificada correctamente.");
        }
    }


}
