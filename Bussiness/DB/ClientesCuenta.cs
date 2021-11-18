using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.DB
{
    public class ClientesCuenta
    {
        public string Cedula { get; set; }
        public string NumeroCuenta { get; set; }

        public virtual Cliente CedulaNavigation { get; set; }
        public virtual Cuenta NumeroCuentaNavigation { get; set; }
    }
}
