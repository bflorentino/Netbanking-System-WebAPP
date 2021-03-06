using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Linq;

namespace Bussiness.BussinesLogic
{
    public class CrudPrestamos
    {
        //static NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
        static NetBanking_Sys_WebAppContext dbContext = Contexto.GetContexto().Ctxto;
        public static bool CreatePrestamo(Model.BindingModel.PrestamoCreateBindingModel  prestamo)
        {
            // Verificar si el cleinte tiene o no cedula
            if (CrudCuentas.ClienteTieneCuenta(prestamo.Cedula) == false)
            {
                return false;
            }
        
            // Verificar si el cliente tiene un prestamo activo o no en el banco antes de agregar un prestamo a un cliente
            if (VerificarPrestamoActivo(prestamo.Cedula))
            {
                return false;
            }

            try
            {
            dbContext.Add(new Prestamo
            {
                CodigoPrestamo = prestamo.CodigoPrestamo,
                FechaInicio = DateTime.Now,
                MontoPrestado = prestamo.MontoPrestado,
                CuotasTotalesAPagar = prestamo.CuotasTotalesAPagar,
                CuotasPagadas = 0,
                PagoPorCuota = prestamo.PagoPorCuota,
                TasaInteres = prestamo.TasaInteres,
                Activo = "Si"
            });

            dbContext.Add(new ClientesPrestamo
            {
                Cedula = prestamo.Cedula,
                CodigoPrestamo = prestamo.CodigoPrestamo
            });

            dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static bool VerificarPrestamoActivo(string numeroCedula)
        {
            var prestamo = (from prestamos in dbContext.Prestamos
                            join clientesPrestamos in dbContext.ClientesPrestamos
                            on prestamos.CodigoPrestamo equals clientesPrestamos.CodigoPrestamo
                            where numeroCedula == clientesPrestamos.Cedula &&
                            prestamos.Activo == "Si" 
                            select prestamos).FirstOrDefault();

            return prestamo != null;
       }

        public static List<Model.ViewModel.Prestamo> GetPrestamos()
        {
            var prestamos = (from prestamo in dbContext.Prestamos
                                    join cPrestamo in dbContext.ClientesPrestamos
                                    on prestamo.CodigoPrestamo equals cPrestamo.CodigoPrestamo
                                    select new Model.ViewModel.Prestamo
                                    {
                                        CodigoPrestamo = prestamo.CodigoPrestamo,
                                        Cedula= cPrestamo.Cedula,
                                        FechaInicio = prestamo.FechaInicio,
                                        MontoPrestado = prestamo.MontoPrestado,
                                        CuotasTotalesAPagar = prestamo.CuotasTotalesAPagar,
                                        CuotasPagadas = prestamo.CuotasPagadas,
                                        PagoPorCuota = prestamo.PagoPorCuota,
                                        Activo = prestamo.Activo
                                    }).ToList();

            return prestamos;
        }

        public static Model.BindingModel.PrestamoEditBindingModel GetPrestamo(string codigoPrestamo)
        {
            // Recupera un prestamo segun el codigo de prestamo recibido

            var loan = (from prestamos in dbContext.Prestamos
                           join clientesPrestamos in dbContext.ClientesPrestamos
                           on prestamos.CodigoPrestamo equals clientesPrestamos.CodigoPrestamo
                           where prestamos.CodigoPrestamo == codigoPrestamo
                           select new Model.BindingModel.PrestamoEditBindingModel
                         {
                             CodigoPrestamo = prestamos.CodigoPrestamo,
                             Cedula = clientesPrestamos.Cedula,
                             FechaInicio = prestamos.FechaInicio,
                             MontoPrestado = prestamos.MontoPrestado,
                             CuotasTotalesAPagar = prestamos.CuotasTotalesAPagar,
                             CuotasPagadas = prestamos.CuotasPagadas,
                             PagoPorCuota = prestamos.PagoPorCuota,
                             TasaInteres = (decimal)prestamos.TasaInteres,
                             Activo = prestamos.Activo,
                         }).FirstOrDefault();

            return loan;
        }

        public static bool UpdatePrestamo(Model.BindingModel.PrestamoEditBindingModel prestamo)
        {
            try
            {
                var loan = dbContext.Prestamos.Where(x => x.CodigoPrestamo == prestamo.CodigoPrestamo).FirstOrDefault();

                loan.MontoPrestado = prestamo.MontoPrestado;
                loan.CuotasTotalesAPagar = prestamo.CuotasTotalesAPagar;
                loan.CuotasPagadas = prestamo.CuotasPagadas;
                loan.PagoPorCuota = prestamo.PagoPorCuota;
                loan.TasaInteres = prestamo.TasaInteres;

                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}