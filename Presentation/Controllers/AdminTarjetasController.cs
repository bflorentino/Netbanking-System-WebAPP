using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AdminTarjetasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
