using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AdminCuentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
