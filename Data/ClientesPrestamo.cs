using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class ClientesPrestamo
    {
        public string Cedula { get; set; }
        public string CodigoPrestamo { get; set; }

        public virtual Cliente CedulaNavigation { get; set; }
        public virtual Prestamo CodigoPrestamoNavigation { get; set; }
    }
}
