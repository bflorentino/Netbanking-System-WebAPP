using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CuentasClientesController : Controller
    {
        public IActionResult VerCuentas()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                   var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                    ViewBag.cuentas = cuentasStrings;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Login", "UsuariosManagement");
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
                   
                    if(cuentasStrings.Count == 0)
                    {
                        return RedirectToAction("SinCuentas");
                    }
                    return View();
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        [HttpPost]
        public IActionResult Transferencia(Bussiness.Model.BindingModel.TransferenciaBindingModel transferencia)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Transferencia");
            }
            return View(transferencia);
        }
        
        public IActionResult Retiros()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    var retiros = Bussiness.BussinesLogic.OperacionesCuentas.GetHistorialRetiros();
                     var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                     ViewBag.cuentas = cuentasStrings;
                     return View(retiros);
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public IActionResult Depositos()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    var depositos = Bussiness.BussinesLogic.OperacionesCuentas.GetHistorialDepositos();
                    var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                    ViewBag.cuentas = cuentasStrings;
                    return View(depositos);
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public PartialViewResult DepositosPorCuenta(string cuenta)
        {
            var depositos = Bussiness.BussinesLogic.OperacionesCuentas.GetHistorialDepositos(cuenta); 
            return PartialView(depositos);
        }

        public IActionResult SinCuentas()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    return View();      
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
    }
}