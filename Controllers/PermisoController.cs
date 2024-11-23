using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2_Mod.Data;
using Practica2_Mod.Models;

namespace Practica2_Mod.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class PermisoController : ControllerBase
 {
  private readonly DataPractica2 _context;
  public PermisoController(DataPractica2 context)
  {
   _context = context;
  }
  [HttpGet("Listar Permiso")]
  public async Task<ActionResult<IEnumerable<Permiso>>> Get()
  {
   var permisos = await _context.Permisos.ToListAsync();
   return Ok(permisos);
  }
  [HttpPost("Registrar")]
  public async Task<ActionResult<Permiso>> Post(Permiso permiso)
  {
   var idempleado = await _context.Empleados.FindAsync(permiso.IdEmpleado);
   permiso.Empleado = idempleado;
   if (_context.Permisos == null)
   {
    return Problem("Entity set 'ApplicationdbContext.Prestamos'  is null.");
   }
   _context.Permisos.Add(permiso);
   await _context.SaveChangesAsync();
   return Ok("Registrado");
  }
  [HttpGet("BuscarId")]
  public async Task<ActionResult<Permiso>> GetId(int id)
  {
   var permisos = await _context.Permisos.FindAsync(id);
   if (permisos == null)
   {
    return NotFound("Permiso no encontrado");
   }
   return Ok(permisos);
  }
  [HttpPut("Modificar")]
  public async Task<ActionResult<Permiso>> Put(Permiso permiso, int id)
  {
   var existeid = await _context.Permisos.FindAsync(id);
   if (existeid == null)
   {
    return NotFound("No encontrado");
   }
   var empleado = await _context.Empleados.FindAsync(permiso.IdEmpleado);
   if (empleado == null)
   {
    return BadRequest("El id esta vacio o no existe");
   }
   existeid.Motivo = permiso.Motivo;
   existeid.Fecha_Permiso = permiso.Fecha_Permiso;
   existeid.Estado = permiso.Estado;
   existeid.IdEmpleado = permiso.IdEmpleado;
   await _context.SaveChangesAsync();
   return Ok("Datos actualizados");
  }
 }
}
