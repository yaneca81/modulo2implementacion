using Caso3.Data;
using Caso3.DTOs;
using Caso3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Caso3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public UsuarioController(RestauranteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioDto
                {
                    UsuarioId = u.UsuarioId,
                    Nombre = u.Nombre,
                    Correo = u.Correo,
                    Contraseña = u.Contraseña,
                    Telefono = u.Telefono
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .Select(u => new UsuarioDto
                {
                    UsuarioId = u.UsuarioId,
                    Nombre = u.Nombre,
                    Correo = u.Correo,
                    Contraseña = u.Contraseña,
                    Telefono = u.Telefono
                })
                .FirstOrDefaultAsync(u => u.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Correo = usuarioDto.Correo,
                Contraseña = usuarioDto.Contraseña,
                Telefono = usuarioDto.Telefono
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioDto usuarioDto)
        {
            if (id != usuarioDto.UsuarioId)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nombre = usuarioDto.Nombre;
            usuario.Correo = usuarioDto.Correo;
            usuario.Contraseña = usuarioDto.Contraseña;
            usuario.Telefono = usuarioDto.Telefono;

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
