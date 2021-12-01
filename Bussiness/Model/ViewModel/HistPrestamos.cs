using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Model.ViewModel
{
     public class HistPrestamos
    {
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public string CodigoPrestamo { get; set; }  
    }
}