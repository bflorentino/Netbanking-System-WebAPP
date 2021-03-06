using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Linq;

namespace Bussiness.BussinesLogic
{
    public class CrudCuentas
    {
        //static readonly NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
        static NetBanking_Sys_WebAppContext dbContext = Contexto.GetContexto().Ctxto;
        public static bool CreateCuenta(Model.BindingModel.CuentaCreateBindingModel cuenta)
        {
            try
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
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
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

        public static Model.BindingModel.CuentaEditBindingModel GetCuenta(string numeroCuenta)
        {
            // Retorna una unica cuenta bancaria especificado por el numero de cuenta

            var cuenta = (from cuentas in dbContext.Cuentas
                          join clienteCuenta in dbContext.ClientesCuentas on cuentas.NumeroCuenta equals clienteCuenta.NumeroCuenta
                          where cuentas.NumeroCuenta == numeroCuenta
                          select new Model.BindingModel.CuentaEditBindingModel
                          {
                              NumeroCuenta = cuentas.NumeroCuenta,
                              FechaCreacion = cuentas.FechaCreacion,
                              Balance = cuentas.Balance,
                              Cedula = clienteCuenta.Cedula
                          }).FirstOrDefault();

            return cuenta;
        }

        public static bool UpdateCuenta(Model.BindingModel.CuentaEditBindingModel cuenta)
        {
            try
            {
                var account = dbContext.Cuentas.Where(c => c.NumeroCuenta == cuenta.NumeroCuenta).FirstOrDefault();

                // Edicion de la cuenta
                account.Balance = cuenta.Balance;
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool ClienteTieneCuenta(string cedula)
        {
            var cuenta = (from cuentas in dbContext.Cuentas 
                         join clienteCuenta in dbContext.ClientesCuentas
                         on cuentas.NumeroCuenta equals clienteCuenta.NumeroCuenta
                         where clienteCuenta.Cedula == cedula
                         select cuentas).ToList();

            return cuenta.Count > 0;
        }
    }
 }