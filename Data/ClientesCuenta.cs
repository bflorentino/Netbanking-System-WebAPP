using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class ClientesCuenta
    {
        public string Cedula { get; set; }
        public string NumeroCuenta { get; set; }

        public virtual Cliente CedulaNavigation { get; set; }
        public virtual Cuenta NumeroCuentaNavigation { get; set; }
    }
}
