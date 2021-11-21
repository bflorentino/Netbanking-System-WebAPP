using Microsoft.AspNetCore.Mvc;
using Bussiness;

namespace Presentation.Controllers
{
    public class AdminCuentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCuenta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCuenta(Bussiness.Model.BindingModel.CuentaCreateBindingModel cuenta)
        {
            if (ModelState.IsValid)
            {
                Bussiness.BussinesLogic.AdmCuentas.CreateCuenta(cuenta);
                return View("ViewCuentas");
            }
            return View(cuenta);
        }

        public IActionResult ViewCuentas()
        {
            var cuentas = Bussiness.BussinesLogic.AdmCuentas.GetCuentas();

             return View(cuentas);
        }

        [HttpPut]
        public IActionResult EditCuenta(string cuentaToUpdate)
        {
            var cuenta = Bussiness.BussinesLogic.AdmCuentas.GetCuenta(cuentaToUpdate);

            return View(cuenta);
        }

        [HttpPost]
        public IActionResult EditCuenta(Bussiness.Model.BindingModel.CuentaEditBindingModel cuenta)
        {
            if (ModelState.IsValid)
            {
                Bussiness.BussinesLogic.AdmCuentas.UpdateCuenta(cuenta);
                return RedirectToAction("ViewCuentas");
            }
            
            return View(cuenta);
        }
    }
}
