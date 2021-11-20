using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.ViewModel
{
    public class Tarjeta
    {
        [Display(Name = "Numero de tarjeta")]
        public string NumeroTarjeta { get; set; }

        public string Cedula { get; set; }  

        [Display(Name = "Validacion")]
        public int ValorDeValidacion { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        public DateTime FechaVencimiento { get; set; }
                    
        [Display(Name="Balance disponible")]
        public decimal BalanceDisponible { get; set; }

        [Display(Name = "Balance Consumido")]
        public decimal? BalanceConsumido { get; set; }

        [Display(Name = "Fecha de expedición")]
        public DateTime FechaExpedicion { get; set; }
    }
}
