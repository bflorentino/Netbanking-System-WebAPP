using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data;

namespace Bussiness.BussinesLogic
{
    public class OperacionesPrestamos
    {
        static NetBanking_Sys_WebAppContext dbContext = Contexto.GetContexto().Ctxto;
        static string  primaryKey;

        private static Prestamo GetPrestamoActivo()
        { 
            var prestamo = (from prestamos in dbContext.Prestamos
                            join clientesPrestamos in dbContext.ClientesPrestamos
                            on prestamos.CodigoPrestamo equals clientesPrestamos.CodigoPrestamo
                            where ManageUsers.UserOnline.Cedula == clientesPrestamos.Cedula &&
                            prestamos.Activo == "Si"
                            select prestamos).FirstOrDefault();

            return prestamo;
        }

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

        public static bool PagarPrestamo(string numeroCuentaOrigen, decimal balance, decimal pagoCuota)
        {
            if (balance >= pagoCuota)
            {
                var prestamo = GetPrestamoActivo();
                prestamo.CuotasPagadas++;

                if(prestamo.CuotasPagadas == prestamo.CuotasTotalesAPagar)
                {
                    prestamo.Activo = "No";
                }

                primaryKey =  new Random().Next(1000000, 9999999).ToString();

                HistorialPagosPrestamo histPago = new HistorialPagosPrestamo
                {
                    CodigoPago = primaryKey,
                    CodigoPrestamo = prestamo.CodigoPrestamo,
                    MontoPagado = prestamo.PagoPorCuota,
                    Fecha = DateTime.Now
                };

                var cuenta = dbContext.Cuentas.Where(x => x.NumeroCuenta == numeroCuentaOrigen).FirstOrDefault();
                cuenta.Balance -= prestamo.PagoPorCuota;
                dbContext.Add(histPago);
                dbContext.SaveChanges();

                return true;
            }
            else 
            {
                return false;
             }
        }

        public static List<Model.ViewModel.HistPrestamos> GetHistPrestamos(string codPrestamo)
        {
            var pagos = (from pago in dbContext.HistorialPagosPrestamos
                         where pago.CodigoPrestamo == codPrestamo
                         select new Model.ViewModel.HistPrestamos
                         {
                             Fecha = pago.Fecha,
                             Monto = pago.MontoPagado,
                             CodigoPrestamo = pago.CodigoPrestamo
                         }).ToList();

            return pagos;
        }

        public static List<Model.ViewModel.HistPrestamos> GetHistPrestamos()
        {
            var hey = ManageUsers.UserOnline;
            var hai = dbContext;
            var heyo = dbContext.ClientesPrestamos;
            

            var pagos = (from pago in dbContext.HistorialPagosPrestamos
                         join clientesP in dbContext.ClientesPrestamos
                         on pago.CodigoPrestamo equals clientesP.CodigoPrestamo
                         where clientesP.Cedula ==  ManageUsers.UserOnline.Cedula
                         select new Model.ViewModel.HistPrestamos
                         {
                             Fecha = pago.Fecha,
                             Monto = pago.MontoPagado,
                            CodigoPrestamo = pago.CodigoPrestamo
                         }).ToList();

            return pagos;
        }

        public static List<string>GetCodigosPrestamos()
        {
            var prestamos = (from prestamo in dbContext.Prestamos
                            join cprestamo  in dbContext.ClientesPrestamos
                            on prestamo.CodigoPrestamo equals cprestamo.CodigoPrestamo
                            where cprestamo.Cedula == ManageUsers.UserOnline.Cedula
                            select prestamo.CodigoPrestamo).ToList();

            return prestamos;
        }
    }
}