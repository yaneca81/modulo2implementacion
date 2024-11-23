using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Modelos;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly DataPractica _context;

        public CitaController(DataPractica context)
        {
            _context = context;
        }

        [HttpPost("Insertar cita")]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            var idPaciente = await _context.Pacientes.FindAsync(cita.IdPaciente);
            cita.Paciente = idPaciente;

            var idMedico = await _context.Medicos.FindAsync(cita.IdMedico);
            cita.Medico = idMedico;

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return Ok(cita);

        }

        [HttpGet("Buscar Cita")]
        public async Task<ActionResult<IEnumerable<Cita>>> BuscarCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound("Cita no encontrado.");
            }

            return Ok(cita);
        }

        [HttpGet("Listar citas")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCita()
        {
            var cita = await _context.Citas.ToListAsync();
            return Ok(cita);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Cita>> Put(Cita cita, int id)
        {
            var exiteId = await _context.Citas.FindAsync(id);
            if (exiteId == null)
            {
                return NotFound("No encontrado");
            }
            var paciente = await _context.Citas.FindAsync(cita.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("el id esta vacio o no existe");
            }
            var medico = await _context.Citas.FindAsync(cita.IdMedico);
            if (medico == null)
            {
                return BadRequest("el id esta vacio o no existe");
            }
            exiteId.Fecha = cita.Fecha;
            exiteId.Hora = cita.Hora;
            exiteId.Estado = cita.Estado;
            exiteId.IdPaciente = cita.IdPaciente;
            exiteId.IdMedico = cita.IdMedico;
            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
    }
}
