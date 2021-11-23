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

        public IActionResult EditTarjeta(string tarjetaToUpdate)
        {
            var tarjeta = Bussiness.BussinesLogic.AdmTarjetas.GetTarjeta(tarjetaToUpdate);

            return View(tarjeta);
        }
        
        [HttpPost]
        public IActionResult EditTarjeta(Bussiness.Model.BindingModel.CreditCardEditBindingModel tarjeta)
        {
            if (ModelState.IsValid)
            {
                Bussiness.BussinesLogic.AdmTarjetas.UpdateTarjeta(tarjeta);
                return RedirectToAction("ViewTarjetas");
            }
            return View(tarjeta);
        }

        public IActionResult ViewTarjetas()
        {
            var tarjetas = Bussiness.BussinesLogic.AdmTarjetas.GetTarjetas();

            return View(tarjetas);
        }
    }
}