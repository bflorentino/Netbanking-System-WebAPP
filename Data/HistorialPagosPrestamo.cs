using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class HistorialPagosPrestamo
    {
        public string CodigoPago { get; set; }
        public string CodigoPrestamo { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Prestamo CodigoPrestamoNavigation { get; set; }
    }
}
