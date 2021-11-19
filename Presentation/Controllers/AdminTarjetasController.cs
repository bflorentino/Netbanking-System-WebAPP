using Microsoft.AspNetCore.Mvc;
using Bussiness;

namespace Presentation.Controllers
{
    public class AdminTarjetasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateTarjeta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTarjeta(Bussiness.Model.BindingModel.CreditCardCreateBindingModel tarjeta)
        {
            if (ModelState.IsValid)
            {
                Bussiness.BussinesLogic.AdmTarjetas.CreateTarjeta(tarjeta);
                return View();
            }

            return View(tarjeta);
        }
    }
}
