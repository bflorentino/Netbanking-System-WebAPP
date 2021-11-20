using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Linq;

namespace Bussiness.BussinesLogic
{
    public class AdmCuentas
    {
        static readonly NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
        
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

        public static List<Model.ViewModel.Cuenta> GetCuentas()
        {
            var cuentas = (from cuenta in dbContext.Cuentas
                                join ClienteCuenta in dbContext.ClientesCuentas on cuenta.NumeroCuenta equals ClienteCuenta.NumeroCuenta
                                select new 
                                {
                                     NumeroC = cuenta.NumeroCuenta, 
                                      BalanceC = cuenta.Balance, 
                                      FechaCreacionC = cuenta.FechaCreacion, 
                                      CedulaC = ClienteCuenta.Cedula 
                                  }).ToList();

            var cuentasViewModel = new List<Model.ViewModel.Cuenta>();

            cuentasViewModel = (from cuenta in cuentas
                               select new Model.ViewModel.Cuenta
                               {
                                   NumeroCuenta = cuenta.NumeroC,
                                   FechaCreacion = cuenta.FechaCreacionC,
                                   Balance = cuenta.BalanceC,
                                   Cedula = cuenta.CedulaC
                               }).ToList();

             return cuentasViewModel;
            }
        }
    }