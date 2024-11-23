using Clinia.Data;
using Clinia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        private readonly DataClinica _context;

        public TratamientoController(DataClinica context)
        {
            _context = context;
        }

        [HttpGet("Listar Tratamientos")]
        public async Task<ActionResult<IEnumerable<Tratamiento>>> GetTratamientos()
        {
            var tratamientos = await _context.Tratamientos.Include(t => t.Historial_Clinico).ToListAsync();
            return Ok(tratamientos);
        }
        [HttpGet("BuscarTratamientoPorId")]
        public async Task<ActionResult<Tratamiento>> BuscarTratamientoPorId(int id)
        {
            var tratamiento = await _context.Tratamientos.FindAsync(id);

            if (tratamiento == null)
            {
                return NotFound("Tratamiento no encontrado.");
            }

            return Ok(tratamiento);
        }
        //[HttpPost("AgregarTratamiento")]
        //public async Task<ActionResult<Tratamiento>> PostTratamiento(Tratamiento tratamiento)
        //{
        //    if (tratamiento == null)
        //    {
        //        return BadRequest("El tratamiento es inválido.");
        //    }

        //    _context.Tratamientos.Add(tratamiento);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("BuscarTratamientoPorId", new { id = tratamiento.Id }, tratamiento);
        //}
        [HttpPost("AgregarTratamiento")]
        public async Task<ActionResult<Tratamiento>> PostTratamiento(Tratamiento tratamiento)
        {
            if (tratamiento == null)
            {
                return BadRequest("El tratamiento es inválido.");
            }

            var paciente = await _context.Pacientes.FindAsync(tratamiento.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("Paciente no encontrado.");
            }

            var medico = await _context.Medicos.FindAsync(tratamiento.IdMedico);
            if (medico == null)
            {
                return BadRequest("Médico no encontrado.");
            }

 
            var historialClinico = await _context.Historial_Clinicos.FindAsync(tratamiento.IdHistorialClinico);
            if (historialClinico == null)
            {
                return BadRequest("Historial clínico no encontrado.");
            }

            tratamiento.Paciente = paciente;
            tratamiento.Medico = medico;
            tratamiento.Historial_Clinico = historialClinico;

            _context.Tratamientos.Add(tratamiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("BuscarTratamientoPorId", new { id = tratamiento.Id }, tratamiento);
        }

        //[HttpPut("EditarTratamiento")]
        //public async Task<ActionResult<Tratamiento>> PutTratamiento(int id, Tratamiento tratamiento)
        //{
        //    if (id != tratamiento.Id)
        //    {
        //        return BadRequest("El ID del tratamiento no coincide.");
        //    }

        //    var tratamientoExistente = await _context.Tratamientos.FindAsync(id);
        //    if (tratamientoExistente == null)
        //    {
        //        return NotFound("Tratamiento no encontrado.");
        //    }

        //    tratamientoExistente.Descripcion = tratamiento.Descripcion;
        //    tratamientoExistente.FechaInicio = tratamiento.FechaInicio;
        //    tratamientoExistente.FechaFin = tratamiento.FechaFin;
        //    tratamientoExistente.IdPaciente = tratamiento.IdPaciente;
        //    tratamientoExistente.IdMedico = tratamiento.IdMedico;
        //    tratamientoExistente.IdHistorialClinico = tratamiento.IdHistorialClinico;

        //    await _context.SaveChangesAsync();

        //    return Ok("Tratamiento actualizado con éxito.");
        //}
        [HttpPut("EditarTratamiento")]
        public async Task<ActionResult<Tratamiento>> PutTratamiento(int id, Tratamiento tratamiento)
        {
            if (id != tratamiento.Id)
            {
                return BadRequest("El ID del tratamiento no coincide.");
            }

            var tratamientoExistente = await _context.Tratamientos.Include(t => t.Paciente).FirstOrDefaultAsync(t => t.Id == id);
            if (tratamientoExistente == null)
            {
                return NotFound("Tratamiento no encontrado.");
            }


            var paciente = await _context.Pacientes.FindAsync(tratamiento.IdPaciente);
            if (paciente == null)
            {
                return BadRequest("Paciente no encontrado.");
            }

            tratamientoExistente.Descripcion = tratamiento.Descripcion;
            tratamientoExistente.FechaInicio = tratamiento.FechaInicio;
            tratamientoExistente.FechaFin = tratamiento.FechaFin;
            tratamientoExistente.Paciente = paciente; 

            await _context.SaveChangesAsync();

            return Ok("Tratamiento actualizado con éxito.");
        }

        [HttpDelete("EliminarTratamiento")]
        public async Task<ActionResult> DeleteTratamiento(int id)
        {
            var tratamiento = await _context.Tratamientos.FindAsync(id);

            if (tratamiento == null)
            {
                return NotFound("Tratamiento no encontrado.");
            }

            _context.Tratamientos.Remove(tratamiento);
            await _context.SaveChangesAsync();

            return Ok("Tratamiento eliminado con éxito.");
        }
    }
}
