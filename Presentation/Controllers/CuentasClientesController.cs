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

        public IActionResult Transferencia()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                    ViewBag.cuentas = cuentasStrings;
                    return View();
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        [HttpPost]
        public IActionResult Transferencia(Bussiness.Model.BindingModel.TransferenciaBindingModel transferencia)
        {
            if (ModelState.IsValid)
            {
                var transferido = Bussiness.BussinesLogic.OperacionesCuentas.RealizarTransferencia(transferencia);
                var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                ViewBag.cuentas = cuentasStrings;
                return View();
            }
            return View(transferencia);
        } 
    }
}