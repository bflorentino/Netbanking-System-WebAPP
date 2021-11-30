using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data;

namespace Bussiness.BussinesLogic
{
    public class OperacionesPrestamos
    {
       static NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
        public static Model.ViewModel.PrestamospC GetPrestamoActivoAsociado()
        {
            // Obtiene un prestamo perteneciente a un cliente el cual este en estado activo
            var prestamo = (from prestamos in dbContext.Prestamos
                            join clientesPrestamos in dbContext.ClientesPrestamos
                            on prestamos.CodigoPrestamo equals clientesPrestamos.CodigoPrestamo
                            where ManageUsers.UserOnline.Cedula == clientesPrestamos.Cedula &&
                            prestamos.Activo == "Si"
                            select new Model.ViewModel.PrestamospC
                            {
                                CodigoPrestamo = prestamos.CodigoPrestamo,
                                MontoPrestado = prestamos.MontoPrestado,
                                //CuotasTotalesAPagar = prestamos.CuotasTotalesAPagar,
                                //CuotasPagadas = prestamos.CuotasPagadas,
                                PagoPorCuota = prestamos.PagoPorCuota,
                                PagoRestante = prestamos.MontoPrestado - (prestamos.CuotasPagadas * prestamos.PagoPorCuota)
                            }).FirstOrDefault();

            return prestamo;
        }

        public List<Model.ViewModel.Prestamo> GetAllPrestamosAsociados()
        {
            // Obtiene todos los prestamos asociados a un cliente en su historial en el banco
            var prestamo = (from prestamos in dbContext.Prestamos
                            join clientesPrestamos in dbContext.ClientesPrestamos
                            on prestamos.CodigoPrestamo equals clientesPrestamos.CodigoPrestamo
                            where ManageUsers.UserOnline.Cedula == clientesPrestamos.Cedula
                            select new Model.ViewModel.Prestamo
                            {
                                CodigoPrestamo = prestamos.CodigoPrestamo,
                                Cedula = clientesPrestamos.Cedula,
                                FechaInicio = prestamos.FechaInicio,
                                MontoPrestado = prestamos.MontoPrestado,
                                CuotasTotalesAPagar = prestamos.CuotasTotalesAPagar,
                                CuotasPagadas = prestamos.CuotasPagadas,
                                PagoPorCuota = prestamos.PagoPorCuota,
                                Activo = prestamos.Activo
                            }).ToList();

            return prestamo;
        }

        public bool PagarPrestamo(string numeroCuentaOrigen, decimal balance, decimal montoPrestado)
        {
            if (balance >= montoPrestado)
            {

                return true;
            }
        }
    }
}