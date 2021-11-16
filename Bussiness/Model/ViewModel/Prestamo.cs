using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.ViewModel
{
    public class Prestamo
    {
        [Display(Name="Codigo del prestamo")]
        public string CodigoPrestamo { get; set; }
        
        [Display(Name="Fecha de inicio")]
        public DateTime FechaInicio { get; set; }
        
        [Display(Name ="Monto prestado")]
        public decimal MontoPrestado { get; set; }
        
        [Display(Name ="Cuotas a pagar")]
        public int CuotasTotalesAPagar { get; set; }
        
        [Display(Name ="Pagos Realizados")]
        public int CuotasPagadas { get; set; }
        
        [Display(Name="Pago por cuota")]
        public decimal PagoPorCuota { get; set; }
    
        [Display(Name="Tasa de interés")]
        public decimal TasaInteres { get; set; }
    
        public string Activo { get; set; }
    }
}
