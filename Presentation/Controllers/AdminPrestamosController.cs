using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AdminPrestamosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
