using Microsoft.AspNetCore.Mvc;
using Bussiness.Model.BindingModel;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AdminClientsController : Controller
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

        public IActionResult CreateClient()
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
                    //ViewBag.Response = "";
                    return View();
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        [HttpPost]
        public IActionResult CreateClient(ClientCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var registrado = Bussiness.BussinesLogic.CrudClientes.CreateCliente(model);
                ViewBag.Response = registrado? "El cliente ha sido ingresado de manera satisfactoria" : "Error al registrar cliente";
                return View();
            }
            return View(model);
        }

        public IActionResult EditCliente(string cedula)
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
                    var cliente = Bussiness.BussinesLogic.CrudClientes.getCliente(cedula);
                    return View(cliente);
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        [HttpPost]
        public IActionResult EditCliente(ClientEditBindingModel cliente)
        {
            if (ModelState.IsValid)
            {
               var actualizado =  Bussiness.BussinesLogic.CrudClientes.updateCliente(cliente);
               ViewBag.Response = !actualizado? null:  "Error al actualizar el registro";
                return RedirectToAction("ViewClientes");
            }
            return View(cliente);
        }

        public IActionResult ViewClientes()
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
                    var clientes =  Bussiness.BussinesLogic.CrudClientes.GetClientes();
                    return View(clientes);
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
    }
}