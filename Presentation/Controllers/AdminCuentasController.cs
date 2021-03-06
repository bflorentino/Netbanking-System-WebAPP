using Microsoft.AspNetCore.Mvc;
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
                    var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                    string foto = usuarioEnLinea.RutaFoto;
                    string rutaFotoSinPerfil = "/IMG/user.png";
                    ViewBag.Foto = rutaFotoSinPerfil;
                    ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
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
                    var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                    string foto = usuarioEnLinea.RutaFoto;
                    string rutaFotoSinPerfil = "/IMG/user.png";
                    ViewBag.Foto = rutaFotoSinPerfil;
                    ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
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
              var registrado =  Bussiness.BussinesLogic.CrudCuentas.CreateCuenta(cuenta);
                ViewBag.Response = registrado ? "Se ha registrado el nuevo prestamo de manera satisfactoria" : "Error al registrar prestamo";
                return View();
            }
            return View(cuenta);
        }

        public IActionResult ViewCuentas()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1)
                {
                    var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                    string foto = usuarioEnLinea.RutaFoto;
                    string rutaFotoSinPerfil = "/IMG/user.png";
                    ViewBag.Foto = rutaFotoSinPerfil;
                    ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
                    var cuentas = Bussiness.BussinesLogic.CrudCuentas.GetCuentas();
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
                    var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                    string foto = usuarioEnLinea.RutaFoto;
                    string rutaFotoSinPerfil = "/IMG/user.png";
                    ViewBag.Foto = rutaFotoSinPerfil;
                    ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
                    var cuenta = Bussiness.BussinesLogic.CrudCuentas.GetCuenta(cuentaToUpdate);
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
                var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                string foto = usuarioEnLinea.RutaFoto;
                string rutaFotoSinPerfil = "/IMG/user.png";
                ViewBag.Foto = rutaFotoSinPerfil;
                ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
                var actualizado =  Bussiness.BussinesLogic.CrudCuentas.UpdateCuenta(cuenta);
                ViewBag.Response = actualizado ? null : "Error al actualizar el registro";
                return View();
            }
            return View(cuenta);
        }
    }
}