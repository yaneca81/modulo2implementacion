using Api_Centro_de_Salud.Data;
using Api_Centro_de_Salud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Centro_de_Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteMedicoController : ControllerBase
    {
        private readonly ConexionDB _context;
        public ExpedienteMedicoController(ConexionDB context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<ExpedienteMedico>> Post(ExpedienteMedico expediente)
        {
            var idPaciente = await _context.Paciente.FindAsync(expediente.IdPaciente);
            expediente.IdPaciente = idPaciente.Id;
            var idMedico = await _context.Medico.FindAsync(expediente.IdMedico);
            expediente.IdMedico = idMedico.Id;
            var res = await _context.ExpedienteMedico.AddAsync(expediente);
            await _context.SaveChangesAsync();
            return Ok("Se ha registrado");
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<ExpedienteMedico>>> Get()
        {
            var expediente = await _context.ExpedienteMedico.ToListAsync();
            return Ok(expediente);
        }
        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<ExpedienteMedico>>> Get(int id)
        {
            var expediente = await _context.ExpedienteMedico.FirstOrDefaultAsync(r => r.Id.Equals(id));
            if (expediente == null)
            {
                return NotFound();
            }
            return Ok(expediente);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<ExpedienteMedico>> Put(ExpedienteMedico expediente, int id)
        {
            var existId = await _context.ExpedienteMedico.FindAsync(id);
            if (existId == null)
            {
                return NotFound("No encontrado");
            }
            var paciente = await _context.Paciente.FindAsync(expediente.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            var medico = await _context.Medico.FindAsync(expediente.IdMedico);
            if (medico == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existId.FechaRegistro = expediente.FechaRegistro;
            existId.Diagnostico = expediente.Diagnostico;
            existId.Tratamiento = expediente.Tratamiento;
            existId.Notas = expediente.Notas;
            existId.IdPaciente = expediente.IdPaciente;
            existId.IdMedico = expediente.IdMedico;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
    }
}
