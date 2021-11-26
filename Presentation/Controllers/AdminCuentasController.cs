﻿using Microsoft.AspNetCore.Mvc;
using Bussiness;

namespace Presentation.Controllers
{
    public class AdminCuentasController : Controller
    {
        public IActionResult Index()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1)
                {
                    return View();
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public IActionResult CreateCuenta()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1)
                {
                    return View();
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
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
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1)
                {
                    var cuentas = Bussiness.BussinesLogic.AdmCuentas.GetCuentas();
                    return View(cuentas);
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public IActionResult EditCuenta(string cuentaToUpdate)
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1)
                {
                    var cuenta = Bussiness.BussinesLogic.AdmCuentas.GetCuenta(cuentaToUpdate);
                    return View(cuenta);
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
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