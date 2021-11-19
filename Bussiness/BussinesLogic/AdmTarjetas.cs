using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Bussiness.BussinesLogic
{
    public class AdmTarjetas
    {
        static NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
        public static void CreateTarjeta(Model.BindingModel.CreditCardCreateBindingModel tarjeta)
        {
            dbContext.Add(new Tarjeta
            {
                NumeroTarjeta = tarjeta.NumeroTarjeta,
                ValorDeValidacion = tarjeta.ValorDeValidacion,
                FechaVencimiento = tarjeta.FechaVencimiento,
                BalanceDisponible = tarjeta.BalanceDisponible,
                BalanceConsumido = 0,
                FechaExpedicion = DateTime.Now
            });

            dbContext.Add(new ClientesTarjeta
            {
                Cedula = tarjeta.Cedula,
                NumeroTarjeta = tarjeta.NumeroTarjeta
            });

            dbContext.SaveChanges();    
        }
    }
}
