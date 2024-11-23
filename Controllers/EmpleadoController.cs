using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2_Mod.Data;
using Practica2_Mod.Models;

namespace Practica2_Mod.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class EmpleadoController : ControllerBase
 {
  private readonly DataPractica2 _context;
  public EmpleadoController(DataPractica2 context)
  {
   _context = context;
  }
  [HttpGet("Listar Empleado")]
  public async Task<ActionResult<IEnumerable<Empleado>>> Get()
  {
   var empleados = await _context.Empleados.ToListAsync();
   return Ok(empleados);
  }
  [HttpPost("Registrar")]
  public async Task<ActionResult<Empleado>> Post(Empleado empleado)
  {
   _context.Empleados.Add(empleado);
   await _context.SaveChangesAsync();
   return Ok("Registrado");
  }
  [HttpGet("BuscarId")]
  public async Task<ActionResult<Empleado>> GetId(int id)
  {
   var empleados = await _context.Empleados.FindAsync(id);
   if (empleados == null)
   {
    return NotFound("Empleado no encontrado");
   }
   return Ok(empleados);
  }
  [HttpGet("Buscar CI")]
  public async Task<ActionResult<Empleado>> GetCI(int ci)
  {
   var empleados = await _context.Empleados.FirstOrDefaultAsync(p => p.Ci == ci);
   if (empleados == null)
   {
    return NotFound("Empleado no encontrado");
   }
   return Ok(empleados);
  }
  [HttpPut("Modificar")]
  public async Task<ActionResult<Empleado>> Put(Empleado empleado, int id)
  {
   var existeid = await _context.Empleados.FindAsync(id);
   if (existeid == null)
   {
    return NotFound("No encontrado");
   }
   existeid.Nombre = empleado.Nombre;
   existeid.Apellido = empleado.Apellido;
   existeid.Ci = empleado.Ci;
   existeid.Cargo = empleado.Cargo;
   existeid.Direccion = empleado.Direccion;
   existeid.Telefono = empleado.Telefono;
   existeid.Estado = empleado.Estado;
   await _context.SaveChangesAsync();
   return Ok("Datos actualizados");
  }
 }
}
