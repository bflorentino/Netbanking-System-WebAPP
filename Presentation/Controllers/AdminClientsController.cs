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
                Bussiness.BussinesLogic.AdmClientes.CreateCliente(model) ;
                return RedirectToAction("ViewClientes");
            }
            return View(model);
        }

        public IActionResult EditCliente(string cedula)
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1)
                {
                    var cliente = Bussiness.BussinesLogic.AdmClientes.getCliente(cedula);
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
                Bussiness.BussinesLogic.AdmClientes.updateCliente(cliente);
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
                   var clientes =  Bussiness.BussinesLogic.AdmClientes.GetClientes();
                    return View(clientes);
                }
                return RedirectToAction("Index", "Clients");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
    }
}