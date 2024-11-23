using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2_Mod.Data;
using Practica2_Mod.Models;

namespace Practica2_Mod.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class CapacitacionController : ControllerBase
 {
  private readonly DataPractica2 _context;
  public CapacitacionController(DataPractica2 context)
  {
   _context = context;
  }
  [HttpGet("Listar Capacitacion")]
  public async Task<ActionResult<IEnumerable<Capacitacion>>> Get()
  {
   var capacitaciones = await _context.Capacitaciones.ToListAsync();
   return Ok(capacitaciones);
  }
  [HttpPost("Registrar")]
  public async Task<ActionResult<Capacitacion>> Post(Capacitacion capacitacion)
  {
   _context.Capacitaciones.Add(capacitacion);
   await _context.SaveChangesAsync();
   return Ok("Registrado");
  }
  [HttpGet("BuscarId")]
  public async Task<ActionResult<Capacitacion>> GetId(int id)
  {
   var capacitaciones = await _context.Capacitaciones.FindAsync(id);
   if (capacitaciones == null)
   {
    return NotFound("Capacitacion no encontrada");
   }
   return Ok(capacitaciones);
  }
  [HttpGet("Buscar Titulo")]
  public async Task<ActionResult<Capacitacion>> GetTitulo(string titulo)
  {
   var capacitaciones = await _context.Capacitaciones.FirstOrDefaultAsync(p => p.Titulo == titulo);
   if (capacitaciones == null)
   {
    return NotFound("Capacitacion no encontrada");
   }
   return Ok(capacitaciones);
  }
  [HttpPut("Modificar")]
  public async Task<ActionResult<Capacitacion>> Put(Capacitacion capacitacion, int id)
  {
   var existeid = await _context.Capacitaciones.FindAsync(id);
   if (existeid == null)
   {
    return NotFound("No encontrado");
   }
   existeid.Titulo = capacitacion.Titulo;
   existeid.Descripcion = capacitacion.Descripcion;
   existeid.Tipo = capacitacion.Tipo;
   existeid.Duracion = capacitacion.Duracion;
   existeid.Fecha_Inicio = capacitacion.Fecha_Inicio;
   existeid.Fecha_Culminacion = capacitacion.Fecha_Culminacion;
   existeid.Estado = capacitacion.Estado;
   await _context.SaveChangesAsync();
   return Ok("Datos actualizados");
  }
 }
}
