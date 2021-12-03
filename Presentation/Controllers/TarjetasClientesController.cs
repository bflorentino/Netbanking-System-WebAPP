using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class TarjetasClientesController : Controller
    {
        public IActionResult Index()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                    string foto = usuarioEnLinea.RutaFoto;
                    string rutaFotoSinPerfil = "/IMG/user.png";
                    ViewBag.Foto = foto ?? rutaFotoSinPerfil;
                    ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
                    return View();
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
        public IActionResult VerTarjetas()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    var tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetTarjetas();

                    if(tarjetas.Count == 0)
                    {
                        var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                        string foto = usuarioEnLinea.RutaFoto;
                        string rutaFotoSinPerfil = "/IMG/user.png";
                        ViewBag.Foto = foto ?? rutaFotoSinPerfil;
                        ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
                        return RedirectToAction("NoTarjeta");
                    }
                    return View(tarjetas);
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public IActionResult NoTarjeta()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                    string foto = usuarioEnLinea.RutaFoto;
                    string rutaFotoSinPerfil = "/IMG/user.png";
                    ViewBag.Foto = foto ?? rutaFotoSinPerfil;
                    ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
                    return View();
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public IActionResult PagoTarjeta()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    ViewBag.cuentas =  Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
         
                    if(ViewBag.cuentas.Count == 0)
                    {
                        return RedirectToAction("SinCuentas", "CuentasClientes");
                    }
            
                    ViewBag.tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetNumeroTarjetas();
                    if (ViewBag.tarjetas.Count == 0)
                    {
                        return RedirectToAction("SinTarjetas");
                    }
                    var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                    string foto = usuarioEnLinea.RutaFoto;
                    string rutaFotoSinPerfil = "/IMG/user.png";
                    ViewBag.Foto = foto ?? rutaFotoSinPerfil;
                    ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
                    return View();
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public JsonResult GetTarjetaBalance(string tarjeta)
        {
            var balance = Bussiness.BussinesLogic.OperacionesTarjetas.GetBalanceConsumido(tarjeta);
            return Json(balance);
        }

        public JsonResult GetTarjetaBalanceDisponible(string tarjeta)
        {
            var balance = Bussiness.BussinesLogic.OperacionesTarjetas.GetBalanceDisponible(tarjeta);
            return Json(balance);
        }

        [HttpPost]
        public IActionResult PagoTarjeta(Bussiness.Model.BindingModel.PagoTarjetaBindingModel pago)
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    if (ModelState.IsValid)
                    {
                        //if (Bussiness.BussinesLogic.OperacionesTarjetas.PagarTarjeta(pago))
                        //{

                        //}

                        var pagado = Bussiness.BussinesLogic.OperacionesTarjetas.PagarTarjeta(pago);
                        return RedirectToAction("PagoTarjeta");
                    }
                    return View(pago);
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public IActionResult VerHistPagos()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    var pagos = Bussiness.BussinesLogic.OperacionesTarjetas.GetHistorialPagos();
                    ViewBag.tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetNumeroTarjetas();
                    return View(pagos);  
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public PartialViewResult PagosPorTarjeta(string tarjeta)
        {
            var tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetHistorialPagos(tarjeta);
            return PartialView(tarjetas);
        }

        public IActionResult Deposito()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    var tarjetas = Bussiness.BussinesLogic.OperacionesTarjetas.GetNumeroTarjetas();
                    var cuentas = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();

                    if(tarjetas.Count == 0 || cuentas.Count == 0)
                    {
                        return RedirectToAction("NoTarjeta");
                    }
                    var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                    string foto = usuarioEnLinea.RutaFoto;
                    string rutaFotoSinPerfil = "/IMG/user.png";
                    ViewBag.Foto = foto ?? rutaFotoSinPerfil;
                    ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
                    ViewBag.cuentas = cuentas;
                    ViewBag.tarjetas = tarjetas;
                    return View();
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        [HttpPost]
        public IActionResult Deposito(Bussiness.Model.BindingModel.PagoDepositoBindingModel deposito)
        {
            if (ModelState.IsValid)
            {
                var pagado = Bussiness.BussinesLogic.OperacionesTarjetas.PagarDeposito(deposito);
                return RedirectToAction("Deposito");
            }
            return View(deposito);
        }

        public IActionResult SinPagos()
        {
            if (Bussiness.BussinesLogic.ManageUsers.UserOnline != null)
            {
                if (Bussiness.BussinesLogic.ManageUsers.UserOnline.IdRol == 2)
                {
                    var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                    string foto = usuarioEnLinea.RutaFoto;
                    string rutaFotoSinPerfil = "/IMG/user.png";
                    ViewBag.Foto = foto ?? rutaFotoSinPerfil;
                    ViewBag.Nombre = usuarioEnLinea.NombreUsuario;
                    return View();
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
    }
}