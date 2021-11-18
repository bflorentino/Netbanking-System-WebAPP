using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AdminClients : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateClient()
        {
            return View();
        }

        public IActionResult EditCliente()
        {
            return View();
        }

        public IActionResult ViewClientes()
        {
            return View();
        }
    }
}
