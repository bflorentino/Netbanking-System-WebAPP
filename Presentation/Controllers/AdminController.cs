using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AdminController : Controller
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
                    ViewBag.Message = "Estas en el modulo de administradores";
                    return View();
                }
                    return RedirectToAction("Index", "Clients");
            }           
                return RedirectToAction("Login", "UsuariosManagement");
        }
    }
}