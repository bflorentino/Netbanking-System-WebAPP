using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data
{
    public partial class Tarjeta
    {
        public Tarjeta()
        {
            ClientesTarjeta = new HashSet<ClientesTarjeta>();
            HistorialDepositos = new HashSet<HistorialDeposito>();
            HistorialRetiros = new HashSet<HistorialRetiro>();
        }


        public string NumeroTarjeta { get; set; }
        public int ValorDeValidacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal BalanceDisponible { get; set; }
        public decimal? BalanceConsumido { get; set; }
        public DateTime FechaExpedicion { get; set; }

        public virtual ICollection<ClientesTarjeta> ClientesTarjeta { get; set; }
        public virtual ICollection<HistorialDeposito> HistorialDepositos { get; set; }
        public virtual ICollection<HistorialRetiro> HistorialRetiros { get; set; }
    }
}
