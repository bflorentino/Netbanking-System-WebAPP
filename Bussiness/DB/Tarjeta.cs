using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.DB
{
    public class Tarjeta
    {
        public string NumeroTarjeta { get; set; }
        public int ValorDeValidacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal BalanceDisponible { get; set; }
        public decimal? BalanceConsumido { get; set; }
        public DateTime FechaExpedicion { get; set; }
    }
}
