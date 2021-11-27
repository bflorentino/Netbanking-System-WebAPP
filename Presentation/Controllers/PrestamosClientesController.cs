using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class PrestamosClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
