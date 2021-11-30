using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Model.ViewModel
{
    public class HistDepositos
    {
        public string CodigoDeposito { get; set; }
        public string NumeroCuentaDestino { get; set; }
        public string TarjetaOrigen { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
