using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CuentasClientesController : Controller
    {
        public IActionResult VerCuentas()
        {
            var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
            ViewBag.cuentas = cuentasStrings;
            return View();
        }

        public JsonResult GetCuentaBalance(string cuenta)
        {
            var balance = Bussiness.BussinesLogic.OperacionesCuentas.GetBalance(cuenta);
            return Json(balance);
        }
    }
}