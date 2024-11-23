using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Modelos;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteController : ControllerBase
    {
        private readonly DataPractica _context;

        public ExpedienteController(DataPractica context)
        {
            _context = context;
        }

        [HttpPost("Insertar expediente")]
        public async Task<ActionResult<Expediente>> PostReserva(Expediente expediente)
        {
            var idPaciente = await _context.Pacientes.FindAsync(expediente.IdPaciente);
            expediente.Paciente = idPaciente;

            var idMedico = await _context.Medicos.FindAsync(expediente.IdMedico);
            expediente.Medico = idMedico;

            _context.Expedientes.Add(expediente);
            await _context.SaveChangesAsync();
            return Ok(expediente);

        }

        [HttpGet("Buscar Expediente")]
        public async Task<ActionResult<IEnumerable<Expediente>>> BuscarExpediente(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            return Ok(expediente);
        }

        [HttpGet("Listar expediente")]
        public async Task<ActionResult<IEnumerable<Expediente>>> GetExpediente()
        {
            var expediente = await _context.Expedientes.ToListAsync();
            return Ok(expediente);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Expediente>> Put(Expediente expediente, int id)
        {
            var exiteId = await _context.Expedientes.FindAsync(id);
            if (exiteId == null)
            {
                return NotFound("No encontrado");
            }
            var paciente = await _context.Expedientes.FindAsync(expediente.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("el id esta vacio o no existe");
            }
            var medico = await _context.Expedientes.FindAsync(expediente.IdMedico);
            if (medico == null)
            {
                return BadRequest("el id esta vacio o no existe");
            }
            exiteId.Fecha_actualizacion = expediente.Fecha_actualizacion;
            exiteId.Descripcion = expediente.Descripcion;
            exiteId.IdPaciente = expediente.IdPaciente;
            exiteId.IdMedico = expediente.IdMedico;
            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
    }
}
