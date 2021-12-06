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
                               NumeroTarjeta = clientestarjetas.NumeroTarjeta,
                              BalanceConsumido = (decimal)cards.BalanceConsumido,
                              MontoDisponible = cards.BalanceDisponible
                           }).ToList();

            return tarjetas;
        }

        public static List<Model.ViewModel.HistRetiros> GetHistorialPagos(string tarjeta)
        {
            // Busqueda de todos los pagos hechos por el cliente en una determinada tarjeta de credito
            var pagos = (from historialRet in dbContext.HistorialRetiros
                           join tarjetas in dbContext.Tarjetas
                           on historialRet.TarjetaDestinoDeposito equals tarjetas.NumeroTarjeta
                           join clienteTarjeta in dbContext.ClientesTarjetas
                           on tarjetas.NumeroTarjeta equals clienteTarjeta.NumeroTarjeta
                            where tarjetas.NumeroTarjeta== tarjeta
                           orderby historialRet.Fecha descending
                           select new Model.ViewModel.HistRetiros
                           {
                               CodigoRetiro = historialRet.CodigoRetiro,
                               CuentaOrigen = historialRet.NumeroCuentaOrigenRetiro,
                               MontoRetirado = historialRet.MontoRetirado,
                               Fecha = historialRet.Fecha
                           }).ToList();
            return pagos;
        }

        public static List<Model.ViewModel.HistRetiros> GetHistorialPagos()
        {
            // Busqueda de todos los retiros hechos por el cliente sin importar la fecha
            var pagos = (from historialRet in dbContext.HistorialRetiros
                           join tarjetas in dbContext.Tarjetas
                           on historialRet.TarjetaDestinoDeposito equals tarjetas.NumeroTarjeta
                           join clienteTarjetas in dbContext.ClientesTarjetas
                           on tarjetas.NumeroTarjeta equals clienteTarjetas.NumeroTarjeta
                           where clienteTarjetas.Cedula == ManageUsers.UserOnline.Cedula
                           orderby historialRet.Fecha descending
                           select new Model.ViewModel.HistRetiros
                           {
                               CodigoRetiro = historialRet.CodigoRetiro,
                               CuentaOrigen = historialRet.NumeroCuentaOrigenRetiro,
                               MontoRetirado = historialRet.MontoRetirado,
                               Fecha = historialRet.Fecha
                           }).ToList();

            return pagos;
        }

        public static decimal GetBalanceConsumido(string tarjeta)
        {
            var card = dbContext.Tarjetas.Where(x => x.NumeroTarjeta == tarjeta).FirstOrDefault();
            return (decimal)card.BalanceConsumido;
        }

        public static decimal GetBalanceDisponible(string tarjeta)
        {
            var card = dbContext.Tarjetas.Where(x => x.NumeroTarjeta == tarjeta).FirstOrDefault();
            return card.BalanceDisponible;
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
                
                if(pago.MontoAPagar > tarjeta.TopeCredito || pago.MontoAPagar > tarjeta.BalanceConsumido)
                {
                    return false;
                }

                tarjeta.BalanceConsumido -= pago.MontoAPagar;
                tarjeta.BalanceDisponible += pago.MontoAPagar;

                // Actualización a la cuenta de ahorro
                var cuenta = dbContext.Cuentas.Find(pago.NumeroCuenta);
                cuenta.Balance -= pago.MontoAPagar;

                // Agregar pago al historial de retiros
                dbContext.Add(new HistorialRetiro
                {
                    CodigoRetiro = new Random().Next(1000000, 10000000).ToString(),
                    NumeroCuentaOrigenRetiro = pago.NumeroCuenta,
                    TarjetaDestinoDeposito = pago.NumeroTarjeta,
                    MontoRetirado = pago.MontoAPagar,
                    Fecha = DateTime.Now
                });
 
                dbContext.SaveChanges();

                return true;
            }
        }

        public static bool PagarDeposito(Model.BindingModel.PagoDepositoBindingModel deposito)
        {
            var tarjeta = dbContext.Tarjetas.Find(deposito.TarjetaOrigen);

            if(tarjeta.BalanceDisponible < deposito.MontoAPagar)
            {
                return false;
            }
            else
            {
                var cuenta = dbContext.Cuentas.Find(deposito.CuentaDestino);
                cuenta.Balance += deposito.MontoAPagar;
                tarjeta.BalanceConsumido += deposito.MontoAPagar;
                tarjeta.BalanceDisponible -= deposito.MontoAPagar;

                dbContext.HistorialDepositos.Add(new HistorialDeposito
                {
                    CodigoDeposito = new Random().Next(10000000, 100000000).ToString(),
                    TarjetaOrigenRetiro = deposito.TarjetaOrigen,
                    NumeroCuentaDestinoDeposito = deposito.CuentaDestino,
                    MontoDepositado = deposito.MontoAPagar,
                    Fecha = DateTime.Now
                });

                dbContext.SaveChanges();
            }
            return true;
        }
    }
}