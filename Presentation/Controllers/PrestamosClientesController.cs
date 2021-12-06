using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class PrestamosClientesController : Controller
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

        public IActionResult VerPrestamos()
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
                    var prestamo = Bussiness.BussinesLogic.OperacionesPrestamos.GetPrestamoActivoAsociado();

                   if(prestamo != null)
                    {
                        ViewBag.message = null;
                    }
                    else
                    {
                        ViewBag.message = "Actualmente no tiene ningún préstamo activo con nosotros";
                    }
                    return View(prestamo);
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public IActionResult PagoPrestamo()
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
                    var prestamo = Bussiness.BussinesLogic.OperacionesPrestamos.GetPrestamoActivoAsociado();

                    if(prestamo == null)
                    {
                        return RedirectToAction("SinPrestamo");
                    }
 
                    var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
                    ViewBag.cuentas = cuentasStrings;

                    Bussiness.Model.BindingModel.PagoPrestamoBindingModel pago = new Bussiness.Model.BindingModel.PagoPrestamoBindingModel
                    {
                        CodigoPrestamo = prestamo.CodigoPrestamo,
                        MontoAPagar = prestamo.PagoPorCuota,
                        MontoPrestado = prestamo.MontoPrestado
                    };
                    return View(pago);
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");
        }

        public IActionResult SinPrestamo()
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

        [HttpPost]
        public IActionResult PagoPrestamo(Bussiness.Model.BindingModel.PagoPrestamoBindingModel pago)
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
                var pagado = Bussiness.BussinesLogic.OperacionesPrestamos.PagarPrestamo(pago.NumeroCuentaOrigen, pago.BalanceCuenta, pago.MontoAPagar);
                ViewBag.Response = pagado ? "El pago se ha procesado correctamente" : "Error al realizar pago";
                return View();
            }
            return View(pago);
        }

        public IActionResult VerHistPrestamos()
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
                    var prestamos = Bussiness.BussinesLogic.OperacionesPrestamos.GetHistPrestamos();
                    ViewBag.prestamos = Bussiness.BussinesLogic.OperacionesPrestamos.GetCodigosPrestamos();
                    return View(prestamos);
                }
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "UsuariosManagement");

        } 

        public PartialViewResult PagosPorPrestamo(string prestamo)
        {
            var prestamos = Bussiness.BussinesLogic.OperacionesPrestamos.GetHistPrestamos(prestamo);
            return PartialView(prestamos);
        }
    }
}