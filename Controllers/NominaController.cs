using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2_Mod.Data;
using Practica2_Mod.Models;

namespace Practica2_Mod.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class NominaController : ControllerBase
 {
  private readonly DataPractica2 _context;
  public NominaController(DataPractica2 context)
  {
   _context = context;
  }
  [HttpGet("Listar Nomina")]
  public async Task<ActionResult<IEnumerable<Nomina>>> Get()
  {
   var nominas = await _context.Nominas.ToListAsync();
   return Ok(nominas);
  }
  [HttpPost("Registrar")]
  public async Task<ActionResult<Nomina>> Post(Nomina nomina)
  {
   var idempleado = await _context.Empleados.FindAsync(nomina.IdEmpleado);
   nomina.Empleado = idempleado;
   if (_context.Nominas == null)
   {
    return Problem("Entity set 'ApplicationdbContext.Prestamos'  is null.");
   }
   _context.Nominas.Add(nomina);
   await _context.SaveChangesAsync();
   return Ok("Registrado");
  }
  [HttpGet("BuscarId")]
  public async Task<ActionResult<Nomina>> GetId(int id)
  {
   var nominas = await _context.Nominas.FindAsync(id);
   if (nominas == null)
   {
    return NotFound("Nomina no encontrada");
   }
   return Ok(nominas);
  }
  [HttpPut("Modificar")]
  public async Task<ActionResult<Nomina>> Put(Nomina nomina, int id)
  {
   var existeid = await _context.Nominas.FindAsync(id);
   if (existeid == null)
   {
    return NotFound("No encontrado");
   }
   var empleado = await _context.Empleados.FindAsync(nomina.IdEmpleado);
   if (empleado == null)
   {
    return BadRequest("El id esta vacio o no existe");
   }
   existeid.Sueldo_Base = nomina.Sueldo_Base;
   existeid.Fecha_Ingreso = nomina.Fecha_Ingreso;
   existeid.Horario_Asignado = nomina.Horario_Asignado;
   existeid.Dias_Trabajados = nomina.Dias_Trabajados;
   existeid.Pagos_extras = nomina.Pagos_extras;
   existeid.Permisos = nomina.Permisos;
   existeid.Total_Descuentos = nomina.Total_Descuentos;
   existeid.Sueldo_total = nomina.Sueldo_total;
   existeid.IdEmpleado = nomina.IdEmpleado;
   await _context.SaveChangesAsync();
   return Ok("Datos actualizados");
  }
 }
}
