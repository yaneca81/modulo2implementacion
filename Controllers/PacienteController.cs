using System.Numerics;
using Actividad2.Data;
using Actividad2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        //declarando la variable que va a trabjar con la conexion
        private readonly DataPractica _context;
        public PacienteController(DataPractica context)
        {
            _context = context;
        }
        [HttpGet("Listar Paciente")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente()
        {
            var paciente = await _context.Pacientes.ToListAsync();
            return Ok(paciente);
        }
        [HttpPost("Registrar Paciente")]
        public async Task<ActionResult<Paciente>> Post(Paciente paciente)
        {
            var pacien = _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return Ok("REGISTRADO");

        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Paciente>> Put(Paciente paciente, int id)
        {
            var existeId = await _context.Pacientes.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }
            existeId.Ci = paciente.Ci;
            existeId.Nombre = paciente.Nombre;
            existeId.Apellido = paciente.Apellido;
            existeId.FechaNac = paciente.FechaNac;
            existeId.Sexo = paciente.Sexo;
            existeId.Telefono = paciente.Telefono;
            existeId.Direccion = paciente.Direccion;
            existeId.EstadoCivil = paciente.EstadoCivil;
            existeId.TipoSeguro = paciente.TipoSeguro;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
        //busqueda por id
        [HttpGet("Buscar id")]
        public async Task<ActionResult<IEnumerable<Paciente>>> Getpaciente(int id)
        {
            var pacientes = await _context.Pacientes.FindAsync(id);
            if (pacientes == null)
            {
                return NotFound();
            }
            return Ok(pacientes);
        }

        [HttpGet("Buscar ci")]
        public async Task<ActionResult<IEnumerable<Paciente>>> Getpaciente(string ci)
        {
            var pacientes = await _context.Pacientes.FirstOrDefaultAsync(p => p.Ci == ci);
            if (pacientes == null)
            {
                return NotFound("CI no encontrado");
            }
            return Ok(pacientes);
        }

        [HttpGet("Buscar por sexo")]
        public async Task<ActionResult<IEnumerable<Paciente>>> Getpaciente2(char sexo)
        {
            var pacientes = await _context.Pacientes.FirstOrDefaultAsync(p => p.Sexo == sexo);
            if (pacientes == null)
            {
                return NotFound("CI no encontrado");
            }
            return Ok(pacientes);
        }

    }
}
