using Api_Centro_de_Salud.Data;
using Api_Centro_de_Salud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Centro_de_Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        private readonly ConexionDB _context;
        public NotificacionController(ConexionDB context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Notificacion>> Post(Notificacion notificacion)
        {
            var idPaciente = await _context.Paciente.FindAsync(notificacion.IdPaciente);
            notificacion.IdPaciente = idPaciente.Id;
            var idMedico = await _context.Medico.FindAsync(notificacion.IdMedico);
            notificacion.IdMedico = idMedico.Id;
            var res = await _context.Notificacion.AddAsync(notificacion);
            await _context.SaveChangesAsync();
            return Ok("Se ha registrado");
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Notificacion>>> Get()
        {
            var notificacion = await _context.Notificacion.ToListAsync();
            return Ok(notificacion);
        }
        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<Notificacion>>> Get(int id)
        {
            var notificacion = await _context.Notificacion.FirstOrDefaultAsync(r => r.Id.Equals(id));
            if (notificacion == null)
            {
                return NotFound();
            }
            return Ok(notificacion);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Notificacion>> Put(Notificacion notificacion, int id)
        {
            var existId = await _context.Notificacion.FindAsync(id);
            if (existId == null)
            {
                return NotFound("No encontrado");
            }
            var paciente = await _context.Paciente.FindAsync(notificacion.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            var medico = await _context.Medico.FindAsync(notificacion.IdMedico);
            if (medico == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existId.FechaEnvio = notificacion.FechaEnvio;
            existId.Mensaje = notificacion.Mensaje;
            existId.Leida = notificacion.Leida;
            existId.IdPaciente = notificacion.IdPaciente;
            existId.IdMedico = notificacion.IdMedico;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
        }
    }
}
