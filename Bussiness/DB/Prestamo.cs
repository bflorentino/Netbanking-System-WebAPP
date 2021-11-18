using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.DB
{
    public class Prestamo
    {
        public string CodigoPrestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal MontoPrestado { get; set; }
        public int CuotasTotalesAPagar { get; set; }
        public int CuotasPagadas { get; set; }
        public decimal PagoPorCuota { get; set; }
        public decimal TasaInteres { get; set; }
        public string Activo { get; set; }
    }
}
