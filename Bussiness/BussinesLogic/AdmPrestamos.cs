using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Linq;

namespace Bussiness.BussinesLogic
{
    public class AdmPrestamos
    {
        static NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();

        public static void CreatePrestamo(Model.BindingModel.PrestamoCreateBindingModel  prestamo)
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
    }
}