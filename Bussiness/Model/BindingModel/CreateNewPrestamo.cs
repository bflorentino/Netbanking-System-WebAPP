using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.BindingModel
{
    internal class CreateNewPrestamo
    {
        [Display(Name = "Codigo del prestamo")]
        [Required(ErrorMessage ="Se requiere el codigo del prestamo")]
        public string CodigoPrestamo { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Se requiere una cantidad como monto prestado")]
        [Display(Name = "Monto prestado")]
        public decimal MontoPrestado { get; set; }

        [Required(ErrorMessage = "Se requiere establecer un número de cuotas")]
        [Display(Name = "Cuotas a pagar")]
        public int CuotasTotalesAPagar { get; set; }

        [Required(ErrorMessage = "Se requiere la cantidad a pagar por cuota")]
        [Display(Name = "Pago por cuota")]
        public decimal PagoPorCuota { get; set; }

        [Required(ErrorMessage = "Se requiere la tasa de interes del prestamo")]
        [Display(Name = "Tasa de interés")]
        public decimal TasaInteres { get; set; }
    }
}