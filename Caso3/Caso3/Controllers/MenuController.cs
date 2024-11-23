using Caso3.Data;
using Caso3.DTOs;
using Caso3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caso3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public MenuController(RestauranteDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuDto>>> GetMenus()
        {
            return await _context.Menus
                .Select(m => new MenuDto
                {
                    MenuId = m.MenuId,
                    RestauranteId = m.RestauranteId,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion,
                    Precio = m.Precio,
                    ImagenUrl = m.ImagenUrl
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDto>> GetMenu(int id)
        {
            var menu = await _context.Menus
                .Select(m => new MenuDto
                {
                    MenuId = m.MenuId,
                    RestauranteId = m.RestauranteId,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion,
                    Precio = m.Precio,
                    ImagenUrl = m.ImagenUrl
                })
                .FirstOrDefaultAsync(m => m.MenuId == id);

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(MenuDto menuDto)
        {
            var menu = new Menu
            {
                RestauranteId = menuDto.RestauranteId,
                Nombre = menuDto.Nombre,
                Descripcion = menuDto.Descripcion,
                Precio = menuDto.Precio,
                ImagenUrl = menuDto.ImagenUrl
            };

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMenu), new { id = menu.MenuId }, menu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, MenuDto menuDto)
        {
            if (id != menuDto.MenuId)
            {
                return BadRequest();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            menu.RestauranteId = menuDto.RestauranteId;
            menu.Nombre = menuDto.Nombre;
            menu.Descripcion = menuDto.Descripcion;
            menu.Precio = menuDto.Precio;
            menu.ImagenUrl = menuDto.ImagenUrl;

            _context.Entry(menu).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
