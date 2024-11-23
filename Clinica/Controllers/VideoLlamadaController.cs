using Clinia.Data;
using Clinia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoLlamadaController : ControllerBase
    {
        private readonly DataClinica _context;

        public VideoLlamadaController(DataClinica context)
        {
            _context = context;
        }

        [HttpGet("Listar Videollamadas")]
        public async Task<ActionResult<IEnumerable<VideoLlamada>>> GetVideollamadas()
        {
            var videollamadas = await _context.VideoLlamadas.Include(v => v.Paciente).Include(v => v.Medico).ToListAsync();
            return Ok(videollamadas);
        }
        [HttpGet("BuscarVideoLlamadaPorId")]
        public async Task<ActionResult<VideoLlamada>> BuscarVideoLlamadaPorId(int id)
        {
            var videoLlamada = await _context.VideoLlamadas.FindAsync(id);

            if (videoLlamada == null)
            {
                return NotFound("Video llamada no encontrada.");
            }

            return Ok(videoLlamada);
        }

        //[HttpPost("AgregarVideoLlamada")]
        //public async Task<ActionResult<VideoLlamada>> PostVideoLlamada(VideoLlamada videoLlamada)
        //{
        //    if (videoLlamada == null)
        //    {
        //        return BadRequest("La videollamada es inválida.");
        //    }

        //    _context.VideoLlamadas.Add(videoLlamada);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("BuscarVideoLlamadaPorId", new { id = videoLlamada.Id }, videoLlamada);
        //}
        [HttpPost("AgregarVideoLlamada")]
        public async Task<ActionResult<VideoLlamada>> PostVideoLlamada(VideoLlamada videoLlamada)
        {
            if (videoLlamada == null)
            {
                return BadRequest("La videollamada es inválida.");
            }

            var paciente = await _context.Pacientes.FindAsync(videoLlamada.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("Paciente no encontrado.");
            }

            var medico = await _context.Medicos.FindAsync(videoLlamada.IdMedico);
            if (medico == null)
            {
                return BadRequest("Médico no encontrado.");
            }

            var cita = await _context.Citas.FindAsync(videoLlamada.IdCita);
            if (cita == null)
            {
                return BadRequest("Cita no encontrada.");
            }

            videoLlamada.Paciente = paciente;
            videoLlamada.Medico = medico;
            videoLlamada.Cita = cita;

            _context.VideoLlamadas.Add(videoLlamada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("BuscarVideoLlamadaPorId", new { id = videoLlamada.Id }, videoLlamada);
        }
        //[HttpPut("EditarVideoLlamada")]
        //public async Task<ActionResult<VideoLlamada>> PutVideoLlamada(int id, VideoLlamada videoLlamada)
        //{
        //    if (id != videoLlamada.Id)
        //    {
        //        return BadRequest("El ID de la videollamada no coincide.");
        //    }

        //    var videoLlamadaExistente = await _context.VideoLlamadas.FindAsync(id);
        //    if (videoLlamadaExistente == null)
        //    {
        //        return NotFound("Video llamada no encontrada.");
        //    }

        //    videoLlamadaExistente.FechaHora = videoLlamada.FechaHora;
        //    videoLlamadaExistente.Estado = videoLlamada.Estado;
        //    videoLlamadaExistente.Enlace = videoLlamada.Enlace;
        //    videoLlamadaExistente.IdCita = videoLlamada.IdCita;
        //    videoLlamadaExistente.IdPaciente = videoLlamada.IdPaciente;
        //    videoLlamadaExistente.IdMedico = videoLlamada.IdMedico;

        //    await _context.SaveChangesAsync();

        //    return Ok("Video llamada actualizada con éxito.");
        //}
        [HttpPut("EditarVideoLlamada")]
        public async Task<ActionResult<VideoLlamada>> PutVideoLlamada(int id, VideoLlamada videoLlamada)
        {
            if (id != videoLlamada.Id)
            {
                return BadRequest("El ID de la videollamada no coincide.");
            }

            var videoLlamadaExistente = await _context.VideoLlamadas
                .Include(v => v.Paciente)
                .Include(v => v.Medico)
                .Include(v => v.Cita)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (videoLlamadaExistente == null)
            {
                return NotFound("Video llamada no encontrada.");
            }

            var paciente = await _context.Pacientes.FindAsync(videoLlamada.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("Paciente no encontrado.");
            }

            var medico = await _context.Medicos.FindAsync(videoLlamada.IdMedico);
            if (medico == null)
            {
                return BadRequest("Médico no encontrado.");
            }

            var cita = await _context.Citas.FindAsync(videoLlamada.IdCita);
            if (cita == null)
            {
                return BadRequest("Cita no encontrada.");
            }

            videoLlamadaExistente.FechaHora = videoLlamada.FechaHora;
            videoLlamadaExistente.Estado = videoLlamada.Estado;
            videoLlamadaExistente.Enlace = videoLlamada.Enlace;

            videoLlamadaExistente.Paciente = paciente;
            videoLlamadaExistente.Medico = medico;
            videoLlamadaExistente.Cita = cita;

            await _context.SaveChangesAsync();

            return Ok("Video llamada actualizada con éxito.");
        }
        [HttpDelete("EliminarVideoLlamada")]
        public async Task<ActionResult> DeleteVideoLlamada(int id)
        {
            var videoLlamada = await _context.VideoLlamadas.FindAsync(id);

            if (videoLlamada == null)
            {
                return NotFound("Video llamada no encontrada.");
            }

            _context.VideoLlamadas.Remove(videoLlamada);
            await _context.SaveChangesAsync();

            return Ok("Video llamada eliminada con éxito.");
        }
    }
}
