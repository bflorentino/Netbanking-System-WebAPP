using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Bussiness.BussinesLogic
{
    public class AdmCuentas
    {
        static NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
        public static void CreateCuenta(Model.BindingModel.CuentaCreateBindingModel cuenta)
        {
            dbContext.Add(new Cuenta
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                Balance = cuenta.Balance,
                FechaCreacion = DateTime.Now,
            });

            dbContext.Add(new ClientesCuenta
            {
                Cedula = cuenta.Cedula,
                NumeroCuenta = cuenta.NumeroCuenta
            });

            dbContext.SaveChanges();
        }
    }
}