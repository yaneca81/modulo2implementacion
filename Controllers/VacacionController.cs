using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2_Mod.Data;
using Practica2_Mod.Models;

namespace Practica2_Mod.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class VacacionController : ControllerBase
 {
  private readonly DataPractica2 _context;
  public VacacionController(DataPractica2 context)
  {
   _context = context;
  }
  [HttpGet("Listar Vacacion")]
  public async Task<ActionResult<IEnumerable<Vacacion>>> Get()
  {
   var vacaciones = await _context.Vacaciones.ToListAsync();
   return Ok(vacaciones);
  }
  [HttpPost("Registrar")]
  public async Task<ActionResult<Vacacion>> Post(Vacacion vacacion)
  {
   var idempleado = await _context.Empleados.FindAsync(vacacion.IdEmpleado);
   vacacion.Empleado = idempleado;
   if (_context.Vacaciones == null)
   {
    return Problem("Entity set 'ApplicationdbContext.Prestamos'  is null.");
   }
   _context.Vacaciones.Add(vacacion);
   await _context.SaveChangesAsync();
   return Ok("Registrado");
  }
  [HttpGet("BuscarId")]
  public async Task<ActionResult<Vacacion>> GetId(int id)
  {
   var Vacaciones = await _context.Vacaciones.FindAsync(id);
   if (Vacaciones == null)
   {
    return NotFound("Vacacion no encontrada");
   }
   return Ok(Vacaciones);
  }
  [HttpPut("Modificar")]
  public async Task<ActionResult<Vacacion>> Put(Vacacion vacacion, int id)
  {
   var existeid = await _context.Vacaciones.FindAsync(id);
   if (existeid == null)
   {
    return NotFound("No encontrado");
   }
   var empleado = await _context.Empleados.FindAsync(vacacion.IdEmpleado);
   if (empleado == null)
   {
    return BadRequest("El id esta vacio o no existe");
   }
   existeid.Fecha_Inicio = vacacion.Fecha_Inicio;
   existeid.Fecha_Culminacion = vacacion.Fecha_Culminacion;
   existeid.Estado = vacacion.Estado;
   existeid.IdEmpleado = vacacion.IdEmpleado;
   await _context.SaveChangesAsync();
   return Ok("Datos actualizados");
  }
 }
}
