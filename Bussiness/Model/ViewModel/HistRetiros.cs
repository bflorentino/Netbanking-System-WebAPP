using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.ViewModel
{
     public class HistRetiros
    {
        [Display(Name ="Numero de retiro")]
        public string CodigoRetiro { get; set; }

        [Display(Name = "Tarjeta de destino")]
        public string TarjetaDestino { get; set; }
        
        [Display(Name = "Monto retirado")]
        public decimal MontoRetirado { get; set; }

        public  DateTime Fecha { get; set; }
        [Display(Name ="Desde cuenta")]
        public string CuentaOrigen { get; set; }
    }
}