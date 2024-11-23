using Microsoft.AspNetCore.Mvc;

namespace SistemaRecursosHumanos.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
