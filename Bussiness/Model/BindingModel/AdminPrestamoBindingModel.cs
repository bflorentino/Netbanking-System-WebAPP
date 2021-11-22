using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.BindingModel
{
    public class PrestamoCreateBindingModel
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

        [Required(ErrorMessage = "Ingrese la cedula del cliente")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El numero de cedula debe de ser de 11 numeros")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Dato invalido, se deben ingresar 11 digitos numericos")]
        public string Cedula { get; set; }
    }

    public class PrestamoEditBindingModel
    {
        [Display(Name = "Codigo del prestamo")]
        [Required(ErrorMessage = "Se requiere el codigo del prestamo")]
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

        [Required(ErrorMessage = "Se requiere la cantidad de cuotas pagadas")]
        [Display(Name = "Cuotas Pagadas")]
        public int CuotasPagadas { get; set; }

        [Required(ErrorMessage = "Se requiere la tasa de interes del prestamo")]
        [Display(Name = "Tasa de interés")]
        public decimal TasaInteres { get; set; }

        [Required(ErrorMessage = "Ingrese la cedula del cliente")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El numero de cedula debe de ser de 11 numeros")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Dato invalido, se deben ingresar 11 digitos numericos")]
        public string Cedula { get; set; }

        public string Activo { get; set; }
    }
}