using Actividad2.Data;
using Actividad2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        //declarando la variable que va a trabjar con la conexion
        private readonly DataPractica _context;
        public CitaController(DataPractica context)
        {
            _context = context;
        }

        [HttpGet("Listar Cita")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetReserva()
        {
            var citas = await _context.Citas.ToListAsync();
            return Ok(citas);
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Cita>> Post(Cita cita)
        {
            if (cita == null)
            {
                return BadRequest("La cita es inválida.");
            }

            var paciente = await _context.Pacientes.FindAsync(cita.IdPaciente);
            var doctor = await _context.Doctores.FindAsync(cita.IdDoctor);

            if (paciente == null || doctor == null)
            {
                return BadRequest("Paciente o médico no encontrados.");
            }

            cita.Paciente = paciente;
            cita.Doctor = doctor;

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return Ok("Cita registrada");
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Cita>> Put(Cita cita, int id)
        {
            var existeId = await _context.Citas.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }
            var doctor = await _context.Citas.FindAsync(cita.IdDoctor);
            if (doctor == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            var paciente = await _context.Citas.FindAsync(cita.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existeId.FechaHora = cita.FechaHora;
            existeId.Motivo = cita.Motivo;
            existeId.Estado = cita.Estado;
            existeId.IdPaciente = cita.IdPaciente;
            existeId.IdDoctor = cita.IdDoctor;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }

        [HttpGet("Buscar çitas segun estado")]
        public async Task<ActionResult<IEnumerable<Cita>>> Getcita(string estado)
        {
            var citas = await _context.Citas.FirstOrDefaultAsync(p => p.Estado == estado);
            if (citas == null)
            {
                return NotFound("CI no encontrado");
            }
            return Ok(citas);
        }
    }
}
