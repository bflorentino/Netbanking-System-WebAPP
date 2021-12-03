using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Linq;

namespace Bussiness.BussinesLogic
{
    public class CrudTarjetas
    {
        //static readonly NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
        static NetBanking_Sys_WebAppContext dbContext = Contexto.GetContexto().Ctxto;
        public static void CreateTarjeta(Model.BindingModel.CreditCardCreateBindingModel tarjeta)
        {
            dbContext.Add(new Tarjeta
            {
                NumeroTarjeta = tarjeta.NumeroTarjeta,
                ValorDeValidacion = tarjeta.ValorDeValidacion,
                FechaVencimiento = tarjeta.FechaVencimiento,
                BalanceDisponible = tarjeta.BalanceDisponible,
                BalanceConsumido = 0,
                TopeCredito = tarjeta.BalanceDisponible,
                FechaExpedicion = DateTime.Now
            });

            dbContext.Add(new ClientesTarjeta
            {
                Cedula = tarjeta.Cedula,
                NumeroTarjeta = tarjeta.NumeroTarjeta
            });

            dbContext.SaveChanges();    
        }

       public static List<Model.ViewModel.Tarjeta> GetTarjetas()
        {
            var tarjetas = (from tarjeta in dbContext.Tarjetas
                                 join clienteCard in dbContext.ClientesTarjetas
                                 on tarjeta.NumeroTarjeta equals clienteCard.NumeroTarjeta                           
                                 select new Model.ViewModel.Tarjeta
                                {
                                   NumeroTarjeta = tarjeta.NumeroTarjeta,
                                   ValorDeValidacion = tarjeta.ValorDeValidacion,
                                   FechaVencimiento = tarjeta.FechaVencimiento,
                                   FechaExpedicion=tarjeta.FechaExpedicion,
                                   BalanceDisponible = tarjeta.BalanceDisponible,
                                   BalanceConsumido = tarjeta.BalanceConsumido,
                                   Cedula = clienteCard.Cedula,
                            }).ToList(); 

            return tarjetas;
        }

       public static Model.BindingModel.CreditCardEditBindingModel GetTarjeta(string numeroTarjeta)
        {
            // Obtiene la tarjeta especificada por parametro

            var tarjeta = (from tarjetas in dbContext.Tarjetas
                           join clientestarjetas in dbContext.ClientesTarjetas
                           on tarjetas.NumeroTarjeta equals clientestarjetas.NumeroTarjeta
                           where tarjetas.NumeroTarjeta == numeroTarjeta
                           select new Model.BindingModel.CreditCardEditBindingModel
                           {
                               NumeroTarjeta = tarjetas.NumeroTarjeta,
                               ValorDeValidacion = tarjetas.ValorDeValidacion,
                               FechaExpedicion = tarjetas.FechaExpedicion,
                               FechaVencimiento = tarjetas.FechaVencimiento,
                               BalanceDisponible = tarjetas.BalanceDisponible,
                               BalanceConsumido = tarjetas.BalanceConsumido,
                               Cedula = clientestarjetas.Cedula
                           }).FirstOrDefault();

            return tarjeta;
        }
        
        public static void UpdateTarjeta(Model.BindingModel.CreditCardEditBindingModel tarjeta)
        {
            var card = dbContext.Tarjetas.Where(x => x.NumeroTarjeta == tarjeta.NumeroTarjeta).FirstOrDefault();
            card.BalanceDisponible = tarjeta.BalanceDisponible;
            dbContext.SaveChanges();
        }
    }
}