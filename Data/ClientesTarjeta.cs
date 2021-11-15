using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class ClientesTarjeta
    {
        public string Cedula { get; set; }
        public string NumeroTarjeta { get; set; }

        public virtual Cliente CedulaNavigation { get; set; }
        public virtual Tarjeta NumeroTarjetaNavigation { get; set; }
    }
}
