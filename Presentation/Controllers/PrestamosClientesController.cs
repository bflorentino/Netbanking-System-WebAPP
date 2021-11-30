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
    }
}