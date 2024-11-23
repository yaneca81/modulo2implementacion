using Actividad2.Data;
using Actividad2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        //declarando la variable que va a trabjar con la conexion
        private readonly DataPractica _context;
        public DoctorController(DataPractica context)
        {
            _context = context;
        }
        [HttpGet("Listar Doctores")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
        {
            var doctor = await _context.Doctores.ToListAsync();
            return Ok(doctor);
        }
        [HttpPost("Registrar Doctores")]
        public async Task<ActionResult<Doctor>> Post(Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest("El docotor es inválida.");
            }

            var especialidad = await _context.Especialidades.FindAsync(doctor.IdEspecialidad);

            if (especialidad == null)
            {
                return BadRequest("Paciente o médico no encontrados.");
            }

            doctor.Especialidad = especialidad;

            _context.Doctores.Add(doctor);
            await _context.SaveChangesAsync();
            return Ok("Doctor registrada");

        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Doctor>> Put(Doctor doctor, int id)
        {
            var existeId = await _context.Doctores.FindAsync(id);
            if (existeId == null)
            {
                return NotFound("No encontrado");
            }
            var espe = await _context.Especialidades.FindAsync(doctor.IdEspecialidad);
            if (espe == null)
            {
                return BadRequest("El id esta vacio o no existe");
            }
            existeId.Id = id;
            existeId.Nombre = doctor.Nombre;
            existeId.Apellido = doctor.Apellido;
            existeId.FechaNac = doctor.FechaNac;
            existeId.Sexo = doctor.Sexo;
            existeId.Telefono = doctor.Telefono;
            existeId.Direccion = doctor.Direccion;
            existeId.EstadoCivil = doctor.EstadoCivil;
            existeId.IdEspecialidad = doctor.IdEspecialidad;
            await _context.SaveChangesAsync();
            return Ok("Los datos fueron modificados");
            ;
        }
        [HttpGet("Buscar doctores por nombre de especialidad")]
        public async Task<ActionResult<IEnumerable<Doctor>>> Getcliente(string nombre)
        {
            var especialidades = await _context.Especialidades.FirstOrDefaultAsync(p => p.Nombre == nombre);
            var id = especialidades.Id;
            var doctores = await _context.Doctores.FirstOrDefaultAsync(p => p.IdEspecialidad == id);
            if (doctores == null)
            {
                return NotFound();
            }
            return Ok(doctores);
        }
    }
}
