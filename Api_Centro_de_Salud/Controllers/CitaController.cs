using Api_Centro_de_Salud.Data;
using Api_Centro_de_Salud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Centro_de_Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ConexionDB _context;
        public CitaController(ConexionDB context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Cita>> Post(Cita cita)
        {
            var idPaciente = await _context.Paciente.FindAsync(cita.IdPaciente);
            cita.IdPaciente = idPaciente.Id;
            var idMedico = await _context.Medico.FindAsync(cita.IdMedico);
            cita.IdMedico = idMedico.Id;
            var res = await _context.Cita.AddAsync(cita);
            await _context.SaveChangesAsync();
            return Ok("Se ha registrado la cita");
        }
        [HttpGet("ListarCitas")]
        public async Task<ActionResult<IEnumerable<Cita>>> Get()
        {
            var cita = await _context.Cita.ToListAsync();
            return Ok(cita);
        }
        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<Cita>>> Get(int id)
        {
            var cita = await _context.Cita.FirstOrDefaultAsync(r => r.Id.Equals(id));
            if (cita == null)
            {
                return NotFound();
            }
            return Ok(cita);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Cita>> Put(Cita cita, int id)
        {
            var existId = await _context.Cita.FindAsync(id);
            if (existId == null)
            {
                return NotFound("No encontrado");
            }
            var paciente = await _context.Paciente.FindAsync(cita.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            var medico = await _context.Medico.FindAsync(cita.IdMedico);
            if (medico == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existId.Fecha = cita.Fecha;
            existId.Motivo = cita.Motivo;
            existId.Estado = cita.Estado;
            existId.IdPaciente = cita.IdPaciente;
            existId.IdMedico = cita.IdMedico;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
    }
}
