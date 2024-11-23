using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleMedicina.Data;
using TeleMedicina.Models;

namespace TeleMedicina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialMedicoController : ControllerBase
    {
        private readonly DataTelemedicina _context;

        public HistorialMedicoController(DataTelemedicina context)
        {
            _context = context;
        }

        // GET: api/HistorialMedico/Listar
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<HistorialMedico>>> GetHistorialMedico()
        {
            var historiales = await _context.HistorialesMedicos.Include(h => h.Paciente).ToListAsync();
            return Ok(historiales);
        }

        // POST: api/HistorialMedico/Registrar
        [HttpPost("Registrar")]
        public async Task<ActionResult> PostHistorialMedico(HistorialMedico historialMedico)
        {
            if (_context.HistorialesMedicos == null)
            {
                return Problem("Entity set 'DataPractica.HistorialesMedicos' is null.");
            }

            var paciente = await _context.Pacientes.FindAsync(historialMedico.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El paciente asociado no existe.");
            }

            historialMedico.Paciente = paciente;
            _context.HistorialesMedicos.Add(historialMedico);
            await _context.SaveChangesAsync();

            return Ok("Historial médico registrado correctamente.");
        }

        // GET: api/HistorialMedico/BuscarId
        [HttpGet("BuscarId/{id}")]
        public async Task<ActionResult<HistorialMedico>> GetHistorialMedicoId(int id)
        {
            var historial = await _context.HistorialesMedicos
                .Include(h => h.Paciente) 
                .FirstOrDefaultAsync(h => h.IdHistorial == id);

            if (historial == null)
            {
                return NotFound("Historial médico no encontrado.");
            }

            return Ok(historial);
        }

        // PUT: api/HistorialMedico/Modificar
        [HttpPut("Modificar/{id}")]
        public async Task<ActionResult> PutHistorialMedico(HistorialMedico historialMedico, int id)
        {
            var existeHistorial = await _context.HistorialesMedicos.FindAsync(id);
            if (existeHistorial == null)
            {
                return NotFound("Historial médico no encontrado.");
            }

            var paciente = await _context.Pacientes.FindAsync(historialMedico.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El paciente asociado no existe.");
            }

            existeHistorial.FechaRegistro = historialMedico.FechaRegistro;
            existeHistorial.Diagnostico = historialMedico.Diagnostico;
            existeHistorial.Notas = historialMedico.Notas;
            existeHistorial.IdPaciente = historialMedico.IdPaciente;

            await _context.SaveChangesAsync();
            return Ok("Historial médico modificado correctamente.");
        }
    }


}
