using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2_Mod.Data;
using Practica2_Mod.Models;

namespace Practica2_Mod.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class CapacitacionEmpleadoController : ControllerBase
 {
  private readonly DataPractica2 _context;
  public CapacitacionEmpleadoController(DataPractica2 context)
  {
   _context = context;
  }
  [HttpGet("Listar")]
  public async Task<ActionResult<IEnumerable<Capacitacion_Empleado>>> Get()
  {
   var capacitacionesEmp = await _context.Capacitaciones_Empleados.ToListAsync();
   return Ok(capacitacionesEmp);
  }
  [HttpPost("Registrar")]
  public async Task<ActionResult<Capacitacion_Empleado>> PostReserva(Capacitacion_Empleado capacitacionempleado)
  {
   var idcapacitacion = await _context.Capacitaciones.FindAsync(capacitacionempleado.IdCapacitacion);
   capacitacionempleado.Capacitacion = idcapacitacion;
   var idempleado = await _context.Empleados.FindAsync(capacitacionempleado.IdEmpleado);
   capacitacionempleado.Empleado = idempleado;
   if (_context.Capacitaciones_Empleados == null)
   {
    return Problem("Entity set 'ApplicationdbContext.Prestamos'  is null.");
   }
   _context.Capacitaciones_Empleados.Add(capacitacionempleado);
   await _context.SaveChangesAsync();
   return Ok("Registrado");
  }
 }
}
