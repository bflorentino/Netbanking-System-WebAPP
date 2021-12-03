using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.ViewModel
{
     public class HistPrestamos
    {
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        [Display(Name ="Numero del prestamo")]
        public string CodigoPrestamo { get; set; }  
    }
}