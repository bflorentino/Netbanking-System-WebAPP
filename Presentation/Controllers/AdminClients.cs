using Microsoft.AspNetCore.Mvc;
using Bussiness.Model.BindingModel;

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

        [HttpPost]
        public IActionResult CreateClient(ClientCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                Bussiness.BussinesLogic.AdmClientes.CreateCliente(model) ;
                return RedirectToAction("CreateClient");
            }

            return View(model);
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
