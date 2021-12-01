using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Model.ViewModel
{
     public class HistRetiros
    {
        public string CodigoRetiro { get; set; }  
        public string TarjetaDestino { get; set; }
        public decimal MontoRetirado { get; set; }
        public  DateTime Fecha { get; set; }
        public string CuentaOrigen { get; set; }
    }
}