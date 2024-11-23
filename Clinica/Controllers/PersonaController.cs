using Clinia.Data;
using Clinica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DataClinica _context;

        public PersonaController(DataClinica context)
        {
            _context = context;
        }

        //[HttpGet("Listar Personas")]
        //public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        //{
        //    var personas = await _context.Personas.ToListAsync();
        //    return Ok(personas);
        //}
        [HttpGet("ListarPersonas")]
        public async Task<ActionResult<IEnumerable<object>>> GetPersonas()
        {
            var personas = await _context.Personas
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Apellido,
                    p.Telefono,
                    Tipo = _context.Pacientes.Any(pa => pa.Id == p.Id) ? "Paciente" :
                           _context.Medicos.Any(m => m.Id == p.Id) ? "Medico" : "N/A"
                })
                .ToListAsync();

            return Ok(personas);
        }
    }
}
