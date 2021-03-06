using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data;

namespace Bussiness.BussinesLogic
{
    public class OperacionesCuentas
    {
        //static readonly NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
        static NetBanking_Sys_WebAppContext dbContext = Contexto.GetContexto().Ctxto;

        // Obtener cuentas asociadas al usuario que esta en linea
        public static List<string> GetCuentasAsociadas()
        {
            var cuentas = (from cuenta in dbContext.Cuentas
                                 join cCuentas in dbContext.ClientesCuentas
                                on cuenta.NumeroCuenta equals cCuentas.NumeroCuenta
                                where cCuentas.Cedula == ManageUsers.UserOnline.Cedula
                                select cCuentas.NumeroCuenta).ToList();

            return cuentas;
        }

        public static decimal GetBalance(string numeroCuenta)
        {          
            var cuenta = dbContext.Cuentas.Find(numeroCuenta).Balance; 
            return cuenta;
        }

        public static bool RealizarTransferencia(Model.BindingModel.TransferenciaBindingModel transferencia)
        {
            // Realizar transferencia bancaria
            try
            {
                var cuentaOrigen = dbContext.Cuentas.Where(x => x.NumeroCuenta == transferencia.CuentaOrigen).FirstOrDefault();
                if(transferencia.Cantidad <= cuentaOrigen.Balance)
                {
                    var cuentaDestino = dbContext.Cuentas.Where(x => x.NumeroCuenta == transferencia.Cuenta).FirstOrDefault();
                    cuentaDestino.Balance += transferencia.Cantidad;
                    cuentaOrigen.Balance -= transferencia.Cantidad;

                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<Model.ViewModel.HistRetiros>GetHistorialRetiros(DateTime fechaInicial, DateTime fechaFinal, string numeroCuenta)
        {
            var retiros = new List<Model.ViewModel.HistRetiros>();
           
            if(fechaInicial != null && fechaFinal != null)
            {
            // Retiros hechos por un cliente en un rango de fecha
                   retiros = (from historialRet in dbContext.HistorialRetiros
                              join cuentas in dbContext.Cuentas
                              on historialRet.NumeroCuentaOrigenRetiro equals numeroCuenta
                              join clienteCuentas in dbContext.ClientesCuentas
                              on cuentas.NumeroCuenta equals clienteCuentas.NumeroCuenta
                              where cuentas.NumeroCuenta == numeroCuenta &&
                              (historialRet.Fecha >= fechaInicial && historialRet.Fecha <= fechaFinal)
                              orderby historialRet.Fecha descending
                              select new Model.ViewModel.HistRetiros
                              {
                                  CodigoRetiro = historialRet.CodigoRetiro,
                                  TarjetaDestino = historialRet.TarjetaDestinoDeposito,
                                  MontoRetirado = historialRet.MontoRetirado,
                                  Fecha = historialRet.Fecha
                              }).ToList();
            }
            return retiros;
        }

        public static List<Model.ViewModel.HistRetiros> GetHistorialRetiros(string numeroCuenta)
        {

            // Busqueda de todos los retiros hechos por el cliente sin importar la fecha en una determinada cuenta
            var retiros = (from historialRet in dbContext.HistorialRetiros
                       join cuentas in dbContext.Cuentas
                       on historialRet.NumeroCuentaOrigenRetiro equals numeroCuenta
                       join clienteCuentas in dbContext.ClientesCuentas
                       on cuentas.NumeroCuenta equals clienteCuentas.NumeroCuenta
                       where cuentas.NumeroCuenta == numeroCuenta
                        orderby historialRet.Fecha descending
                       select new Model.ViewModel.HistRetiros
                       {
                           CodigoRetiro = historialRet.CodigoRetiro,
                           TarjetaDestino = historialRet.TarjetaDestinoDeposito,
                           MontoRetirado = historialRet.MontoRetirado,
                           Fecha = historialRet.Fecha
                       }).ToList();
            return retiros;
        }

        public static List<Model.ViewModel.HistRetiros> GetHistorialRetiros()
        {
            // Busqueda de todos los retiros hechos por el cliente sin importar la fecha
            var retiros = (from historialRet in dbContext.HistorialRetiros
                           join cuentas in dbContext.Cuentas
                           on historialRet.NumeroCuentaOrigenRetiro equals cuentas.NumeroCuenta
                           join clienteCuentas in dbContext.ClientesCuentas
                           on cuentas.NumeroCuenta equals clienteCuentas.NumeroCuenta
                           where clienteCuentas.Cedula == ManageUsers.UserOnline.Cedula
                           orderby historialRet.Fecha descending
                           select new Model.ViewModel.HistRetiros
                           {
                               CodigoRetiro = historialRet.CodigoRetiro,
                               TarjetaDestino = historialRet.TarjetaDestinoDeposito,
                               MontoRetirado = historialRet.MontoRetirado,
                               Fecha = historialRet.Fecha
                           }).ToList();

            return retiros;
        }

        public static List<Model.ViewModel.HistDepositos> GetHistorialDepositos(DateTime fechaInicial, DateTime fechaFinal, string numeroCuenta)
        {
            var depositos = new List<Model.ViewModel.HistDepositos>();
            if (fechaInicial != null && fechaFinal != null)
            {
                // Retiros hechos por un cliente en un rango de fecha
                depositos = (from historialDep in dbContext.HistorialDepositos
                             join cuentas in dbContext.Cuentas
                             on historialDep.NumeroCuentaDestinoDeposito equals numeroCuenta
                             join clienteCuentas in dbContext.ClientesCuentas
                             on cuentas.NumeroCuenta equals clienteCuentas.NumeroCuenta
                             where cuentas.NumeroCuenta == numeroCuenta && 
                             (historialDep.Fecha >= fechaInicial && historialDep.Fecha <= fechaFinal)
                             orderby historialDep.Fecha descending
                             select new Model.ViewModel.HistDepositos
                             {
                                 CodigoDeposito = historialDep.CodigoDeposito,
                                 TarjetaOrigen = historialDep.TarjetaOrigenRetiro,
                                 NumeroCuentaDestino = numeroCuenta,
                                 Monto = historialDep.MontoDepositado,
                                 Fecha = historialDep.Fecha
                             }).ToList();
            }
            return depositos;
        }

        public static List<Model.ViewModel.HistDepositos> GetHistorialDepositos(string numeroCuenta)
        {
            var depositos = new List<Model.ViewModel.HistDepositos>();

            depositos = (from historialDep in dbContext.HistorialDepositos
                         join cuentas in dbContext.Cuentas
                         on historialDep.NumeroCuentaDestinoDeposito equals numeroCuenta
                         join clienteCuentas in dbContext.ClientesCuentas
                         on cuentas.NumeroCuenta equals clienteCuentas.NumeroCuenta
                         where cuentas.NumeroCuenta == numeroCuenta
                         orderby historialDep.Fecha descending
                         select new Model.ViewModel.HistDepositos
                         {
                             CodigoDeposito = historialDep.CodigoDeposito,
                             TarjetaOrigen = historialDep.TarjetaOrigenRetiro,
                             NumeroCuentaDestino = numeroCuenta,
                             Monto = historialDep.MontoDepositado,
                             Fecha = historialDep.Fecha
                         }).ToList();
        
            return depositos;
        }

        public static List<Model.ViewModel.HistDepositos> GetHistorialDepositos()
        {
             var depositos = new List<Model.ViewModel.HistDepositos>();
            
            depositos = (from historialDep in dbContext.HistorialDepositos
                         join cuentas in dbContext.Cuentas
                         on historialDep.NumeroCuentaDestinoDeposito equals cuentas.NumeroCuenta
                         join clienteCuentas in dbContext.ClientesCuentas
                         on cuentas.NumeroCuenta equals clienteCuentas.NumeroCuenta
                         where clienteCuentas.Cedula == ManageUsers.UserOnline.Cedula
                         orderby historialDep.Fecha descending
                         select new Model.ViewModel.HistDepositos
                         {
                             CodigoDeposito = historialDep.CodigoDeposito,
                             TarjetaOrigen = historialDep.TarjetaOrigenRetiro,
                             NumeroCuentaDestino = cuentas.NumeroCuenta,
                             Monto = historialDep.MontoDepositado,
                             Fecha = historialDep.Fecha
                         }).ToList();

            return depositos;
        }
    }
}