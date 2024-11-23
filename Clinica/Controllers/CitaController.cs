using Clinia.Data;
using Clinia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly DataClinica _context;

        public CitaController(DataClinica context)
        {
            _context = context;
        }

        [HttpGet("ListarCitas")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            var citas = await _context.Citas.Include(c => c.Paciente).Include(c => c.Medico).ToListAsync();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> BuscarCitaPorId(int id)
        {
            var cita = await _context.Citas.FindAsync(id);

            if (cita == null)
            {
                return NotFound("Cita no encontrada.");
            }

            return Ok(cita);
        }

        //[HttpPost("AgregarCita")]
        //public async Task<ActionResult<Cita>> PostCita(Cita cita)
        //{
        //    if (cita == null)
        //    {
        //        return BadRequest("La cita es inválida.");
        //    }

        //    _context.Citas.Add(cita);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("BuscarCitaPorId", new { id = cita.Id }, cita);
        //}
        [HttpPost("AgregarCita")]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            if (cita == null)
            {
                return BadRequest("La cita es inválida.");
            }

            var paciente = await _context.Pacientes.FindAsync(cita.IdPaciente);
            var medico = await _context.Medicos.FindAsync(cita.IdMedico);

            if (paciente == null || medico == null)
            {
                return BadRequest("Paciente o médico no encontrados.");
            }

            cita.Paciente = paciente;
            cita.Medico = medico;

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("BuscarCitaPorId", new { id = cita.Id }, cita);
        }

        //[HttpPut("EditarCita")]
        //public async Task<ActionResult<Cita>> PutCita(int id, Cita cita)
        //{
        //    if (id != cita.Id)
        //    {
        //        return BadRequest("El ID de la cita no coincide.");
        //    }

        //    var citaExistente = await _context.Citas.FindAsync(id);
        //    if (citaExistente == null)
        //    {
        //        return NotFound("Cita no encontrada.");
        //    }

        //    citaExistente.Motivo = cita.Motivo;
        //    citaExistente.Fecha_cita = cita.Fecha_cita;
        //    citaExistente.Estado = cita.Estado;
        //    citaExistente.IdPaciente = cita.IdPaciente;
        //    citaExistente.IdMedico = cita.IdMedico;

        //    await _context.SaveChangesAsync();

        //    return Ok("Cita modificada con éxito.");
        //}
        [HttpPut("EditarCita")]
        public async Task<ActionResult> PutCita(int id, Cita cita)
        {
            if (id != cita.Id)
            {
                return BadRequest("El ID de la cita no coincide.");
            }

            var citaExistente = await _context.Citas.Include(c => c.Paciente).Include(c => c.Medico).FirstOrDefaultAsync(c => c.Id == id);

            if (citaExistente == null)
            {
                return NotFound("Cita no encontrada.");
            }

            var paciente = await _context.Pacientes.FindAsync(cita.IdPaciente);
            var medico = await _context.Medicos.FindAsync(cita.IdMedico);

            if (paciente == null || medico == null)
            {
                return BadRequest("Paciente o médico no encontrados.");
            }

            citaExistente.Motivo = cita.Motivo;
            citaExistente.Fecha_cita = cita.Fecha_cita;
            citaExistente.Estado = cita.Estado;
            citaExistente.Paciente = paciente; 
            citaExistente.Medico = medico;     

            await _context.SaveChangesAsync();

            return Ok("Cita modificada con éxito.");
        }
        [HttpDelete("EliminarCita")]
        public async Task<ActionResult> DeleteCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);

            if (cita == null)
            {
                return NotFound("Cita no encontrada.");
            }

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();

            return Ok("Cita eliminada con éxito.");
        }

    }
}
