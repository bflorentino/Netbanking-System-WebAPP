using Microsoft.AspNetCore.Mvc;
using Bussiness;

namespace Presentation.Controllers
{
    public class AdminTarjetasController : Controller
    {
        public IActionResult Index()
        {
            if(Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if(Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1)
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

        public IActionResult CreateTarjeta()
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
        public IActionResult CreateTarjeta(Bussiness.Model.BindingModel.CreditCardCreateBindingModel tarjeta)
        {
            if (ModelState.IsValid)
            {
                var registrado = Bussiness.BussinesLogic.CrudTarjetas.CreateTarjeta(tarjeta);
                ViewBag.Response = registrado ? "La nueva tarjeta ha sido ingresado de manera satisfactoria" : "Error al registrar tarjeta";
                return RedirectToAction("ViewTarjetas");
            }

            return View(tarjeta);
        }

        public IActionResult EditTarjeta(string tarjetaToUpdate)
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
                    var tarjeta = Bussiness.BussinesLogic.CrudTarjetas.GetTarjeta(tarjetaToUpdate);
                    return View(tarjeta);
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
        
        [HttpPost]
        public IActionResult EditTarjeta(Bussiness.Model.BindingModel.CreditCardEditBindingModel tarjeta)
        {
            if (ModelState.IsValid)
            {
               var actualizado =  Bussiness.BussinesLogic.CrudTarjetas.UpdateTarjeta(tarjeta);
               ViewBag.Response = actualizado ? null : "Error al registrar cliente";
               return RedirectToAction("ViewTarjetas");
            }
            return View(tarjeta);
        }

        public IActionResult ViewTarjetas()
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
                    var tarjetas = Bussiness.BussinesLogic.CrudTarjetas.GetTarjetas();
                    return View(tarjetas);
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
    }
}