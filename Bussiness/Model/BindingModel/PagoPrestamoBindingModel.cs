using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Model.BindingModel
{
    public class PagoPrestamoBindingModel
    {
        public string CodigoPrestamo { get; set; }
        public string NumeroCuentaOrigen { get; set; }
        public decimal BalanceCuenta { get; set; }
        public decimal MontoAPagar { get; set; }
        public decimal MontoPrestado { get; set; }
    }
}