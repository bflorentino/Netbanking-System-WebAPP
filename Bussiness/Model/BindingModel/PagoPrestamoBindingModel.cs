using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.BindingModel
{
    public class PagoPrestamoBindingModel
    {
        [Display(Name = "Codigo del prestamo")]
        [Required(ErrorMessage = "Se requiere el codigo del prestamo")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El codigo del prestamo debe de ser de 10 numeros")]
        public string CodigoPrestamo { get; set; }

        [Display(Name = "Numero de cuenta")]
        [Required(ErrorMessage = "Se require un número de cuenta")]
        [StringLength(20, MinimumLength = 20, ErrorMessage = "El numero de cuenta debe ser de 20 numeros")]
        [RegularExpression("[0-9]{20}", ErrorMessage = "Dato invalido, se deben ingresar 20 digitos numericos")]
        public string NumeroCuentaOrigen { get; set; }

        [Display(Name = "Balance de la cuenta")]
        [Required(ErrorMessage ="Seleccione un numero de cuenta")]
        public decimal BalanceCuenta { get; set; }

        [Display(Name = "Monto a pagar")]
        [Required(ErrorMessage ="Se requiere un monto a pagar")]
        public decimal MontoAPagar { get; set; }

        [Display(Name = "Monto Prestado")]
        public decimal MontoPrestado { get; set; }
    }
}