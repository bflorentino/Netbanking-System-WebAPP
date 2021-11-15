using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            ClientesCuenta = new HashSet<ClientesCuenta>();
            HistorialDepositos = new HashSet<HistorialDeposito>();
            HistorialRetiros = new HashSet<HistorialRetiro>();
        }

        public string NumeroCuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<ClientesCuenta> ClientesCuenta { get; set; }
        public virtual ICollection<HistorialDeposito> HistorialDepositos { get; set; }
        public virtual ICollection<HistorialRetiro> HistorialRetiros { get; set; }
    }
}
