using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Modelos;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DataPractica _context;
        public PacienteController(DataPractica context)
        {
            _context = context;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<Paciente>> Post(Paciente paciente)
        {
            var pacien = _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return Ok("Registrado");
        }

        [HttpGet("Listar Paciente")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetCLiente()
        {
            var paciente = await _context.Pacientes.ToListAsync();
            return Ok(paciente);
        }

        [HttpGet("Buscar Paciente")]
        public async Task<ActionResult<IEnumerable<Paciente>>> BuscarPaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound("paciente no encontrado.");
            }

            return Ok(paciente);
        }

        [HttpPut("Modificar")]
        public async Task<ActionResult<Paciente>> Put(Paciente paciente, int id)
        {
            var exiteId = await _context.Pacientes.FindAsync(id);
            if (exiteId == null)
            {
                return NotFound("No encontrado");
            }
            exiteId.Nombre= paciente.Nombre;
            exiteId.Apellido= paciente.Apellido;
            exiteId.Fecha_Nacimiento= paciente.Fecha_Nacimiento;
            exiteId.Direccion= paciente.Direccion;
            exiteId.Historial_Medico= paciente.Historial_Medico;
            exiteId.Telefono= paciente.Telefono;
            exiteId.Correo= paciente.Correo;    
            await _context.SaveChangesAsync();
            return Ok("Datos modificados");
        }
        [HttpDelete("EliminarPaciente")]
        public async Task<ActionResult> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound("Paciente no encontrado.");
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return Ok("Paciente eliminado con éxito.");
        }
    }
}
