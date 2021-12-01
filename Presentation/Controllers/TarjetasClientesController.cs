using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class TarjetasClientesController : Controller
    {
        public IActionResult VerTarjetas()
        {
            var tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetTarjetas();

            if(tarjetas.Count == 0)
            {
                return RedirectToAction("NoTarjeta");
            }
            return View(tarjetas);
        }

        public IActionResult NoTarjeta()
        {
            return View();
        }

        public IActionResult PagoTarjeta()
        {
            return View();
        }
    }
}
