using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Estas en el modulo de clientes";
            return View();
        }
    }
}
