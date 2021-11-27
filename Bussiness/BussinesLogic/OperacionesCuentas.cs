using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data;

namespace Bussiness.BussinesLogic
{
    public class OperacionesCuentas
    {
        static readonly NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();

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
            var cuenta = dbContext.Cuentas.Where(x => x.NumeroCuenta == numeroCuenta).FirstOrDefault();

            return cuenta.Balance;
        }

        public static bool RealizarTransferencia(Model.BindingModel.TransferenciaBindingModel transferencia)
        {
            // Realizar transferencia bancaria
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
    }
}