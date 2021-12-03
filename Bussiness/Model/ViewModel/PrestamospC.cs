using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.ViewModel
{
    public class PrestamospC
    {
        [Display(Name = "Codigo del prestamo")]
        public string CodigoPrestamo { get; set; }

        [Display(Name = "Monto prestado")]
        public decimal MontoPrestado { get; set; }

        [Display(Name = "Pago por cuota")]
        public decimal PagoPorCuota { get; set; }

        [Display(Name="Pago restante")]
        public decimal PagoRestante { get; set; }
    }
}
