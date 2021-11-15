using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class HistorialRetiro
    {
        public string CodigoRetiro { get; set; }
        public string NumeroCuentaOrigenRetiro { get; set; }
        public string TarjetaDestinoDeposito { get; set; }
        public decimal MontoRetirado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Cuenta NumeroCuentaOrigenRetiroNavigation { get; set; }
        public virtual Tarjeta TarjetaDestinoDepositoNavigation { get; set; }
    }
}
