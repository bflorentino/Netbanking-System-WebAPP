using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.BindingModel
{
  public class PagoTarjetaBindingModel
    {
        public decimal MontoAPagar { get; set; }
        public decimal BalanceCuenta { get; set; }
        public string NumeroCuenta { get; set; }    
        public string NumeroTarjeta { get; set; }
        public decimal BalanceConsumidoTarjeta { get; set; }    
    }
}