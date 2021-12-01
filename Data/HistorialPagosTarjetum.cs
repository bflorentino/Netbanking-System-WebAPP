using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class HistorialPagosTarjetum
    {
        public string CodigoPago { get; set; }
        public string NumeroTarjeta { get; set; }
        public string NumeroCuentaOrigen { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Cuenta NumeroCuentaOrigenNavigation { get; set; }
        public virtual Tarjeta NumeroTarjetaNavigation { get; set; }
    }
}
