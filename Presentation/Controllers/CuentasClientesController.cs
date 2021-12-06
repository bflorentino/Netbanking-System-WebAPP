using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;

namespace Presentation.Controllers
{
    public class CuentasClientesController : Controller
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

        public IActionResult VerCuentas()
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
                    var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                    ViewBag.cuentas = cuentasStrings;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }
        
        public JsonResult GetCuentaBalance(string cuenta)
        {
            var balance = Bussiness.BussinesLogic.OperacionesCuentas.GetBalance(cuenta);
            return Json(balance);
        }

        public IActionResult Transferencia()
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
                    var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                    ViewBag.cuentas = cuentasStrings;
                   
                    if(cuentasStrings.Count == 0)
                    {
                        return RedirectToAction("SinCuentas");
                    }
                    return View();
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        [HttpPost]
        public IActionResult Transferencia(Bussiness.Model.BindingModel.TransferenciaBindingModel transferencia)
        {
                var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                var usuarioEnLinea = Bussiness.BussinesLogic.ManageUsers.UserOnline;
                string foto = usuarioEnLinea.RutaFoto;
                ViewBag.cuentas = cuentasStrings;
                string rutaFotoSinPerfil = "/IMG/user.png";
                ViewBag.Foto = foto ?? rutaFotoSinPerfil;
                ViewBag.Nombre = usuarioEnLinea.NombreUsuario;

            if (ModelState.IsValid)
            {
                var transferido = Bussiness.BussinesLogic.OperacionesCuentas.RealizarTransferencia(transferencia);

                ViewBag.Response = transferido ? "La transferencia se ha realizado exitosamente" : 
                    "Error al realizar transferencia.Asegurese de tener balance suficiente en su cuenta de ahorro seleccionada ";
                return View();
            }
            return View(transferencia);
        }
        
        public IActionResult Retiros()
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
                    var retiros = Bussiness.BussinesLogic.OperacionesCuentas.GetHistorialRetiros();
                     var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                     ViewBag.cuentas = cuentasStrings;
                     return View(retiros);
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public IActionResult Depositos()
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
                    var depositos = Bussiness.BussinesLogic.OperacionesCuentas.GetHistorialDepositos();
                    var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                    ViewBag.cuentas = cuentasStrings;
                    return View(depositos);
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public PartialViewResult DepositosPorCuenta(string cuenta)
        {
            var depositos = Bussiness.BussinesLogic.OperacionesCuentas.GetHistorialDepositos(cuenta); 
            return PartialView(depositos);
        }

        public IActionResult SinCuentas()
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

        public PartialViewResult DepositosEntreFecha(DateTime FechaIn, DateTime FechaFin, string cuenta)
        {
            var depositos = Bussiness.BussinesLogic.OperacionesCuentas.GetHistorialDepositos(FechaIn, FechaFin, cuenta);
            return PartialView(depositos);
        }
    
        public PartialViewResult RetirosEntreFechas(DateTime FechaIn, DateTime FechaFin, string cuenta)
        {
            var retiros = Bussiness.BussinesLogic.OperacionesCuentas.GetHistorialRetiros(FechaIn, FechaFin, cuenta);
            return PartialView(retiros);
        }

        public PartialViewResult RetirosPorCuenta(string cuenta)
        {
            var retiros = Bussiness.BussinesLogic.OperacionesCuentas.GetHistorialRetiros(cuenta);
            return PartialView(retiros);
        }
    }
}