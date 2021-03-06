using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Bussiness;

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
                usuario.RutaFoto = nombreFoto;
            }

            var registrado = Bussiness.BussinesLogic.ManageUsers.AddNewUser(usuario);
            ViewBag.Response = "No fue posible registrarse. Intente con otro nombre de usuario o asegurese de ser cliente de la entidad bancaria";
            
            if (registrado)
            {
                Bussiness.Model.BindingModel.LoginUsuarioBindingModel user = new Bussiness.Model.BindingModel.LoginUsuarioBindingModel
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Password = usuario.PasswordHashed
                };
                Bussiness.BussinesLogic.ManageUsers.SetUserOnline(user);
                return RedirectToAction("Index", "Clients");
            }

            return View();
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

                    return Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 1 ?
                        RedirectToAction("Index", "Admin") :
                        RedirectToAction("Index", "Clients");
                }
                else
                {
                    ViewBag.Message = "Usuario invalido. El nombre de usuario ingresado o la contraseña ingresada son invalidos";
                }
            }
            return View(usuario);
        }

        public IActionResult LogOut()
        {
            Bussiness.BussinesLogic.ManageUsers.LogoutApp();
            return RedirectToAction("Login");
        }
    }
}