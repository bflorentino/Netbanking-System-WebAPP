using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.ViewModel
{
    public class VerTarjeta
    {
        [Display(Name = "Numero de tarjeta")]
        public string NumeroTarjeta { get; set; }

        [Display(Name ="Balance consumido")]
        public decimal BalanceConsumido { get; set; }

        [Display(Name ="Monto disponible")]
        public decimal MontoDisponible { get; set; }    
    }
}