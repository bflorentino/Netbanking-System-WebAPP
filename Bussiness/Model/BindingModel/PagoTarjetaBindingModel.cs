using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.BindingModel
{
  public class PagoTarjetaBindingModel
    {
        [Display(Name = "Monto a pagar")]
        [Required(ErrorMessage = "Se requiere un monto a pagar")]
        public decimal MontoAPagar { get; set; }

        [Display(Name = "Balance de la cuenta")]
        [Required(ErrorMessage ="Seleccione un numero de cuenta")]
        public decimal BalanceCuenta { get; set; }

        [Display(Name="Numero de cuenta")]
        [Required(ErrorMessage ="Seleccione un numero de cuenta")]
        public string NumeroCuenta { get; set; }    

        [Display(Name="Numero de tarjeta")]
        [Required(ErrorMessage ="Seleccione una tarjeta de credito")]
        public string NumeroTarjeta { get; set; }

        [Display(Name ="Balance consumido")]
        [Required(ErrorMessage = "Seleccione una tarjeta de credito")]
        public decimal BalanceConsumidoTarjeta { get; set; }    
    }
}