using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class PrestamosClientesController : Controller
    {
        public IActionResult VerPrestamos()
        {
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

        public IActionResult PagoPrestamo()
        {
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

        public IActionResult SinPrestamo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PagoPrestamo(Bussiness.Model.BindingModel.PagoPrestamoBindingModel pago)
        {
            var cuentasStrings = Bussiness.BussinesLogic.OperacionesCuentas.GetCuentasAsociadas();
            ViewBag.cuentas = cuentasStrings;
            var pagado = Bussiness.BussinesLogic.OperacionesPrestamos.PagarPrestamo(pago.NumeroCuentaOrigen, pago.BalanceCuenta, pago.MontoAPagar);
            return RedirectToAction("PagoPrestamo");
        }

        public IActionResult VerHistPrestamos()
        {
            var prestamos = Bussiness.BussinesLogic.OperacionesPrestamos.GetHistPrestamos();
            ViewBag.prestamos = Bussiness.BussinesLogic.OperacionesPrestamos.GetCodigosPrestamos();
            return View(prestamos);
        } 

        public PartialViewResult PagosPorPrestamo(string prestamo)
        {
            var prestamos = Bussiness.BussinesLogic.OperacionesPrestamos.GetHistPrestamos(prestamo);
            return PartialView(prestamos);
        }
    }
}