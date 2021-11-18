using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.BindingModel
{
    public class CreditCardCreateBindingModel
    {
        [Display(Name = "Numero de tarjeta")]
        [Required (ErrorMessage ="Ingrese un numero para la tarjeta")]
        public string NumeroTarjeta { get; set; }

        [Display(Name = "Validacion")]
        [Required(ErrorMessage = "Se requiere un código de validación")]
        public int ValorDeValidacion { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        [Required(ErrorMessage = "Se requiere la fecha de vencimiento de la tarjeta")]
        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Balance disponible")]
        public decimal BalanceDisponible { get; set; }

        [Display(Name = "Balance Consumido")]
        public decimal? BalanceConsumido { get; set; }

        [Display(Name = "Fecha de expedición")]
        public DateTime FechaExpedicion { get; set; }

        [Required(ErrorMessage = "Ingrese la cedula del cliente")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El numero de cedula debe de ser de 11 numeros")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Dato invalido, se deben ingresar 11 digitos numericos")]
        public string Cedula { get; set; }
    }

    public class CreditCardEditBindingModel
    {
        [Display(Name = "Balance disponible")]
        public decimal BalanceDisponible { get; set; }

        [Display(Name = "Balance Consumido")]
        public decimal? BalanceConsumido { get; set; }

        [Display(Name = "Fecha de expedición")]
        public DateTime FechaExpedicion { get; set; }

        [Required(ErrorMessage = "Ingrese la cedula del cliente")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El numero de cedula debe de ser de 11 numeros")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Dato invalido, se deben ingresar 11 digitos numericos")]
        public string Cedula { get; set; }
    }

}
