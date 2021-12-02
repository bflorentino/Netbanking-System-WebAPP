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

        public JsonResult GetTarjetaBalanceDisponible(string tarjeta)
        {
            var balance = Bussiness.BussinesLogic.OperacionesTarjetas.GetBalanceDisponible(tarjeta);
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

        public IActionResult VerHistPagos()
        {
            var pagos = Bussiness.BussinesLogic.OperacionesTarjetas.GetHistorialPagos();
            ViewBag.tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetNumeroTarjetas();
            return View(pagos);  
        }

        public PartialViewResult PagosPorTarjeta(string tarjeta)
        {
            var tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetHistorialPagos(tarjeta);
            return PartialView(tarjetas);
        }

        public IActionResult Deposito()
        {
            var tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetNumeroTarjetas();
            var cuentas = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();

            if(tarjetas.Count == 0 || cuentas.Count == 0)
            {
                return RedirectToAction("NoTarjeta");
            }

            ViewBag.cuentas = cuentas;
            ViewBag.tarjetas = tarjetas;

            return View();
        }

        [HttpPost]
        public IActionResult Deposito(Bussiness.Model.BindingModel.PagoDepositoBindingModel deposito)
        {
            var pagado = Bussiness.BussinesLogic.OperacionesTarjetas.PagarDeposito(deposito);
            return RedirectToAction("Deposito");
        }

        public IActionResult SinPagos()
        {
            return View();
        }
    }
}