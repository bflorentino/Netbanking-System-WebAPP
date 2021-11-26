using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            if(Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if(Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    ViewBag.Message = "Estas en el modulo de clientes";     
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
    }
}