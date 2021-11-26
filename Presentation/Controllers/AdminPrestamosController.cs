using Microsoft.AspNetCore.Mvc;
using Bussiness;

namespace Presentation.Controllers
{
    public class AdminPrestamosController : Controller
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

        public IActionResult CreatePrestamo()
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
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1)
                {
                    var prestamo = Bussiness.BussinesLogic.AdmPrestamos.GetPrestamo(prestamoToUpdate);
                    return View(prestamo);
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
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
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1)
                {
                    var prestamos = Bussiness.BussinesLogic.AdmPrestamos.GetPrestamos();
                    return View(prestamos);
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
    }
}