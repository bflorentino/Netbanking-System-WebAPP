using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Bussiness.Model;

namespace Presentation.Controllers
{
    public class UsuariosManagementController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public UsuariosManagementController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegistroUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistroUsuario(IFormFile Foto)
        {
            Bussiness.Model.BindingModel.UsersCreateBindingModel usuario = new Bussiness.Model.BindingModel.UsersCreateBindingModel
            {
                Cedula = Request.Form["Cedula"],
                PasswordHashed = Request.Form["PasswordHashed"],
                NombreUsuario = Request.Form["NombreUsuario"]
            };

            if (Foto != null) 
            {
                string WebRoot = _env.WebRootPath;
                string nombreFoto = Path.GetFileName(Foto.FileName);
                string ruta = Path.Combine(WebRoot, nombreFoto);
                Foto.CopyTo(new FileStream(ruta, FileMode.Create));
                usuario.RutaFoto = ruta;
            }

            Bussiness.BussinesLogic.ManageUsers.AddNewUser(usuario);

            return RedirectToAction("RegistroUsuario");
        }
        
        public IActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

       [HttpPost]
       public IActionResult Login(Bussiness.Model.BindingModel.LoginUsuarioBindingModel usuario)
        {
            if (ModelState.IsValid)
            {
               bool validarUsuario =  Bussiness.BussinesLogic.ManageUsers.IsUserValid(usuario);

                if (validarUsuario)
                {
                    Bussiness.BussinesLogic.ManageUsers.SetUserOnline(usuario);                
                    return RedirectToAction("RegistroUsuario");
                }
                else
                {
                    ViewBag.Message = "Usuario invalido. El nombre de usuario ingresado o la contraseña ingresada son invalidos";
                }
            }
            return View(usuario);
        }
    }
}