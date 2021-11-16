using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
