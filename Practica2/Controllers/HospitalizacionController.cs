using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Modelos;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizacionController : ControllerBase
    {
        private readonly DataPractica _context;

        public HospitalizacionController(DataPractica context)
        {
            _context = context;
        }

        [HttpPost("Insertar hospitalizacion")]
        public async Task<ActionResult<Hospitalizacion>> PostHopitalizacion(Hospitalizacion hospitalizacion)
        {
            var idPaciente = await _context.Pacientes.FindAsync(hospitalizacion.IdPaciente);
            hospitalizacion.Paciente = idPaciente;

            var idMedico = await _context.Medicos.FindAsync(hospitalizacion.IdMedico);
            hospitalizacion.Medico = idMedico;

            _context.Hospitalizaciones.Add(hospitalizacion);
            await _context.SaveChangesAsync();
            return Ok(hospitalizacion);

        }

        [HttpGet("Buscar Hospitalizacion")]
        public async Task<ActionResult<IEnumerable<Hospitalizacion>>> BuscarHospitalizacion(int id)
        {
            var hospitalizacion = await _context.Hospitalizaciones.FindAsync(id);
            if (hospitalizacion == null)
            {
                return NotFound("hospitalizacion no fue encontrado.");
            }

            return Ok(hospitalizacion);
        }

        [HttpGet("Listar Hospitalizaciones")]
        public async Task<ActionResult<IEnumerable<Hospitalizacion>>> GetCita()
        {
            var hospitalizacion = await _context.Hospitalizaciones.ToListAsync();
            return Ok(hospitalizacion);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Hospitalizacion>> Put(Hospitalizacion hospitalizacion, int id)
        {
            var exiteId = await _context.Hospitalizaciones.FindAsync(id);
            if (exiteId == null)
            {
                return NotFound("No encontrado");
            }
            var paciente = await _context.Hospitalizaciones.FindAsync(hospitalizacion.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("el id esta vacio o no existe");
            }
            var medico = await _context.Hospitalizaciones.FindAsync(hospitalizacion.IdMedico);
            if (medico == null)
            {
                return BadRequest("el id esta vacio o no existe");
            }
            exiteId.Fecha_ingreso  = hospitalizacion.Fecha_ingreso;
            exiteId.Fecha_alta = hospitalizacion.Fecha_alta;
            exiteId.Motivo = hospitalizacion.Motivo;
            exiteId.IdPaciente = hospitalizacion.IdPaciente;
            exiteId.IdMedico = hospitalizacion.IdMedico;
            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
    }
}
