using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            ClientesPrestamos = new HashSet<ClientesPrestamo>();
            HistorialPagosPrestamos = new HashSet<HistorialPagosPrestamo>();
        }

        public string CodigoPrestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal MontoPrestado { get; set; }
        public int CuotasTotalesAPagar { get; set; }
        public int CuotasPagadas { get; set; }
        public decimal PagoPorCuota { get; set; }
        public decimal? TasaInteres { get; set; }
        public string Activo { get; set; }

        public virtual ICollection<ClientesPrestamo> ClientesPrestamos { get; set; }
        public virtual ICollection<HistorialPagosPrestamo> HistorialPagosPrestamos { get; set; }
    }
}
