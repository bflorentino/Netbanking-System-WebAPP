﻿using Microsoft.AspNetCore.Mvc;
using Bussiness;

namespace Presentation.Controllers
{
    public class AdminPrestamosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePrestamo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePrestamo(Bussiness.Model.BindingModel.PrestamoCreateBindingModel prestamo)
        {
            if (ModelState.IsValid)
            {
               Bussiness.BussinesLogic.AdmPrestamos.CreatePrestamo(prestamo);
                return View();
            }
            return View(prestamo);
        }

        public IActionResult EditPrestamo(string prestamoToUpdate)
        {
            var prestamo = Bussiness.BussinesLogic.AdmPrestamos.GetPrestamo(prestamoToUpdate);

            return View(prestamo);
        }

        [HttpPost]
        public IActionResult EditPrestamo(Bussiness.Model.BindingModel.PrestamoEditBindingModel prestamo)
        {
            if (ModelState.IsValid)
            {
                Bussiness.BussinesLogic.AdmPrestamos.UpdatePrestamo(prestamo);
                return RedirectToAction("ViewPrestamos");
            }
            return View(prestamo);
        }

        public IActionResult ViewPrestamos()
        {
            var prestamos = Bussiness.BussinesLogic.AdmPrestamos.GetPrestamos();

            return View(prestamos);
        }
    }
}
