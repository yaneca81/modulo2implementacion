using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataPractica _context;
        public UsuarioController(DataPractica context)
        {
            _context = context;
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<Usuario>> Post(Usuario cliente)
        {
            var clientes = _context.Usuarios.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok("Registrado");
        }
        [HttpGet("Listar Usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            var cliente = await _context.Usuarios.ToListAsync();
            return Ok(cliente);
        }
        [HttpPut("Modificar")]
        public async Task<ActionResult<Usuario>> PutUsuario(Usuario cliente, int id)
        {
            var exiteId = await _context.Usuarios.FindAsync(id);
            if (exiteId == null)
            {
                return NotFound("No encretrado");
            }
            exiteId.Nombre = cliente.Nombre;
            exiteId.Aprellido = cliente.Aprellido;
            exiteId.Correo = cliente.Correo;
            exiteId.Contraseña = cliente.Contraseña;
            exiteId.Telefono = cliente.Telefono;
            exiteId.Rol = cliente.Rol;
            await _context.SaveChangesAsync();
            return Ok("Datos Modificados");
        }
        [HttpGet("Buscar por NOmbre")]
        public async Task<ActionResult<IEnumerable<Usuario>>>GetUsuario(string nombre)
        {
            var clientes = await _context.Usuarios.FirstOrDefaultAsync(t => t.Nombre == nombre);       if (clientes == null)
            {
                return NotFound();
            }
            return Ok(clientes);
        }
    }
}
