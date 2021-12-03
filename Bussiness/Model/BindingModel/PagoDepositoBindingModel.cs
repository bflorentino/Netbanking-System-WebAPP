using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.BindingModel
{
    public class PagoDepositoBindingModel
    {
        [Display(Name = "Numero de tarjeta")]
        [Required(ErrorMessage = "Seleccione una tarjeta de credito")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "El numero de cedula debe de ser de 16 numeros")]
        [RegularExpression("[0-9]{16}", ErrorMessage = "Dato invalido, se deben ingresar 16 digitos numericos")]
        public string TarjetaOrigen { get; set; }

        [Display(Name ="Monto de la tarjeta")]
        [Required(ErrorMessage ="Seleccione una tarjeta")]
        public decimal MontoTarjeta { get; set;}

        [Display(Name ="Cuenta destino")]
        [Required(ErrorMessage = "Se requiere seleccionar un numero de cuenta para realizar el deposito")]
        public string CuentaDestino { get; set; }   

        [Display(Name = "Monto a depositar")]
        [Required(ErrorMessage ="Se requiere una cantidad para depositar")]
        public decimal MontoAPagar { get; set; }
    }
}