using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class HistorialDeposito
    {
        public string CodigoDeposito { get; set; }
        public string TarjetaOrigenRetiro { get; set; }
        public string NumeroCuentaDestinoDeposito { get; set; }
        public decimal MontoDepositado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Cuenta NumeroCuentaDestinoDepositoNavigation { get; set; }
        public virtual Tarjeta TarjetaOrigenRetiroNavigation { get; set; }
    }
}
