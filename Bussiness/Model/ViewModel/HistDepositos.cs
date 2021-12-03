using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.ViewModel
{
    public class HistDepositos
    {
        [Display(Name ="Numero del deposito")]
        public string CodigoDeposito { get; set; }

        [Display(Name = "Cuenta destino")]
        public string NumeroCuentaDestino { get; set; }

        [Display(Name = "Desde tarjeta")]
        public string TarjetaOrigen { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}