using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data;

namespace Bussiness.BussinesLogic
{
    public class OperacionesTarjetas
    {
        static NetBanking_Sys_WebAppContext dbContext = Contexto.GetContexto().Ctxto;
        public static List<Model.ViewModel.VerTarjeta> GetTarjetas()
        {
            var tarjetas = (from cards in dbContext.Tarjetas
                           join clientestarjetas in dbContext.ClientesTarjetas 
                           on cards.NumeroTarjeta equals clientestarjetas.NumeroTarjeta
                           where ManageUsers.UserOnline.Cedula == clientestarjetas.Cedula
                           select new Model.ViewModel.VerTarjeta
                           {
                              BalanceConsumido = (decimal)cards.BalanceConsumido,
                              MontoDisponible = cards.BalanceDisponible
                           }).ToList();

            return tarjetas;
        }
        
        public static decimal GetBalanceConsumido(string tarjeta)
        {
            var card = dbContext.Tarjetas.Where(x => x.NumeroTarjeta == tarjeta).FirstOrDefault();
            return (decimal)card.BalanceConsumido;
        }
    }
}
