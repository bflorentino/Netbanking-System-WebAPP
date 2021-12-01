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
            ViewBag.cuentas =  Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
         
            if(ViewBag.cuentas.Count == 0)
            {
                return RedirectToAction("SinCuentas", "CuentasClientes");
            }
            
            ViewBag.tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetNumeroTarjetas();
            if (ViewBag.tarjetas.Count == 0)
            {
                return RedirectToAction("SinTarjetas");
            }
            return View();
        }

        public JsonResult GetTarjetaBalance(string tarjeta)
        {
            var balance = Bussiness.BussinesLogic.OperacionesTarjetas.GetBalanceConsumido(tarjeta);
            return Json(balance);
        }

        [HttpPost]
        public IActionResult PagoTarjeta(Bussiness.Model.BindingModel.PagoTarjetaBindingModel pago)
        {
            ViewBag.cuentas = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
            ViewBag.tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetNumeroTarjetas();
            if (ModelState.IsValid)
            {
                //if (Bussiness.BussinesLogic.OperacionesTarjetas.PagarTarjeta(pago))
                //{

                //}
                var pagado = Bussiness.BussinesLogic.OperacionesTarjetas.PagarTarjeta(pago);
                return View();
            }
            return View(pago);
        }
    }
}