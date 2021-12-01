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

        public static List<string> GetNumeroTarjetas()
        {
            var tarjetas = (from cards in dbContext.Tarjetas
                            join clientestarjetas in dbContext.ClientesTarjetas
                            on cards.NumeroTarjeta equals clientestarjetas.NumeroTarjeta
                            where ManageUsers.UserOnline.Cedula == clientestarjetas.Cedula
                            select cards.NumeroTarjeta).ToList();

            return tarjetas;
        }

        public static bool PagarTarjeta(Model.BindingModel.PagoTarjetaBindingModel pago)
        {
            if(pago.BalanceCuenta < pago.MontoAPagar)
            {
                return false;
            }
            else
            {
                // Actualización a la tarjeta de credito
                var tarjeta = dbContext.Tarjetas.Find(pago.NumeroTarjeta);
                tarjeta.BalanceConsumido -= pago.MontoAPagar;
                tarjeta.BalanceDisponible += pago.MontoAPagar;

                // Actualización a la cuenta de ahorro
                var cuenta = dbContext.Cuentas.Find(pago.NumeroCuenta);
                cuenta.Balance -= pago.MontoAPagar;

                // Agregar pago al historial de retiros
                dbContext.Add(new HistorialRetiro
                {
                    CodigoRetiro = new Random().Next(1000000, 1000000).ToString(),
                    NumeroCuentaOrigenRetiro = pago.NumeroCuenta,
                    TarjetaDestinoDeposito = pago.NumeroTarjeta,
                    MontoRetirado = pago.MontoAPagar,
                    Fecha = DateTime.Now
                });
                
                dbContext.SaveChanges();

                return true;
            }
        }
    }
}