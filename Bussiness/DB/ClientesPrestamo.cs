using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.DB
{
    public class ClientesPrestamo
    {
        public string Cedula { get; set; }
        public string CodigoPrestamo { get; set; }

        public virtual Cliente CedulaNavigation { get; set; }
        public virtual Prestamo CodigoPrestamoNavigation { get; set; }
    }
}
