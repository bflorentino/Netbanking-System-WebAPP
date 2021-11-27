using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class TarjetasClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
