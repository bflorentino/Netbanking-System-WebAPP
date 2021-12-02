using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Model.BindingModel
{
    public class PagoDepositoBindingModel
    {
        public string TarjetaOrigen { get; set; }
        public decimal MontoTarjeta { get; set; }
        public string CuentaDestino { get; set; }   
        public decimal MontoAPagar { get; set; }
    }
}