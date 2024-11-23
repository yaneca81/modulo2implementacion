using Api_Centro_de_Salud.Data;
using Api_Centro_de_Salud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Centro_de_Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizacionController : ControllerBase
    {
        private readonly ConexionDB _context;
        public HospitalizacionController(ConexionDB context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Hospitalizacion>> Post(Hospitalizacion hospitalizacion)
        {
            var idPaciente = await _context.Paciente.FindAsync(hospitalizacion.IdPaciente);
            hospitalizacion.IdPaciente = idPaciente.Id;
            var idEnfermero = await _context.Enfermero.FindAsync(hospitalizacion.IdEnfermero);
            hospitalizacion.IdEnfermero = idEnfermero.Id;
            var res = await _context.Hospitalizacion.AddAsync(hospitalizacion);
            await _context.SaveChangesAsync();
            return Ok("Se ha registrado");
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Hospitalizacion>>> Get()
        {
            var hospitalizacion = await _context.Hospitalizacion.ToListAsync();
            return Ok(hospitalizacion);
        }
        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<Hospitalizacion>>> Get(int id)
        {
            var hospitalizacion = await _context.Hospitalizacion.FirstOrDefaultAsync(r => r.Id.Equals(id));
            if (hospitalizacion == null)
            {
                return NotFound();
            }
            return Ok(hospitalizacion);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Hospitalizacion>> Put(Hospitalizacion hospitalizacion, int id)
        {
            var existId = await _context.Hospitalizacion.FindAsync(id);
            if (existId == null)
            {
                return NotFound("No encontrado");
            }
            var paciente = await _context.Paciente.FindAsync(hospitalizacion.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            var enfermero = await _context.Enfermero.FindAsync(hospitalizacion.IdEnfermero);
            if (enfermero == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existId.FechaIngreso = hospitalizacion.FechaIngreso;
            existId.Diagnostico = hospitalizacion.Diagnostico;
            existId.Habitacion = hospitalizacion.Habitacion;
            existId.FechaAlta = hospitalizacion.FechaAlta;
            existId.IdPaciente = hospitalizacion.IdPaciente;
            existId.IdEnfermero = hospitalizacion.IdEnfermero;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
    }
}
