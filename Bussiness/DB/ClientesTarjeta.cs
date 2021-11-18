using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.DB
{
    public class ClientesTarjeta
    {
        public string Cedula { get; set; }
        public string NumeroTarjeta { get; set; }

        public virtual Cliente CedulaNavigation { get; set; }
        public virtual Tarjeta NumeroTarjetaNavigation { get; set; }
    }
}
}
