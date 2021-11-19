using System;
using System.Collections.Generic;
using System.Text;
using Data;

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
    }
}