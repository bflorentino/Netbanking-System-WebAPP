using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Bussiness.BussinesLogic
{
    public class CrudClientes
    {
        /// <summary>
        /// 
        /// </summary>
        static NetBanking_Sys_WebAppContext dbContext = Contexto.GetContexto().Ctxto;
        public static bool CreateCliente(Model.BindingModel.ClientCreateBindingModel cliente)
        {
            try
            {
                    dbContext.Add(new Cliente
                    {
                        Cedula = cliente.Cedula,
                        Nombre = cliente.Nombre,
                        Apellido = cliente.Apellido,
                        FechaNacimiento = cliente.FechaNacimiento,
                        Telefono = cliente.Telefono,
                        Direccion = cliente.Direccion,
                        CorreoElectronico = cliente.CorreoElectronico
                    });

                    dbContext.SaveChanges();
                   return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static List<Model.ViewModel.Cliente> GetClientes() // Retorna todos los clientes registrados (Reporte de clientes)
        {
            var clientes = (from cliente in dbContext.Clientes
                            select cliente).ToList();

            var listaClientesViewModel = new List<Model.ViewModel.Cliente>();

            foreach (Cliente cliente in clientes)
            {
                listaClientesViewModel.Add(new Model.ViewModel.Cliente
                {
                    Cedula = cliente.Cedula,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    FechaNacimiento = cliente.FechaNacimiento,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    CorreoElectronico = cliente.CorreoElectronico
                });
            }
            return listaClientesViewModel;
        }

        public static Model.BindingModel.ClientEditBindingModel getCliente(string cedula)
        {
            // Retorna un unico cliente especificado por cedula

            var cliente = (from client in dbContext.Clientes
                           where client.Cedula == cedula
                           select new Model.BindingModel.ClientEditBindingModel
                           {
                               Cedula = client.Cedula,
                               Nombre = client.Nombre,
                               Apellido = client.Apellido,
                               FechaNacimiento = client.FechaNacimiento,
                               Direccion = client.Direccion,
                               Telefono = client.Telefono,
                               CorreoElectronico = client.CorreoElectronico
                           }).FirstOrDefault();

            return cliente;
        }

        public static bool updateCliente(Model.BindingModel.ClientEditBindingModel cliente)
        {
            // Actualiza la informacion del cliente recibido por parametro
            try
            {
                var project = dbContext.Clientes.Where(c => c.Cedula == cliente.Cedula).FirstOrDefault();

                project.Nombre = cliente.Nombre;
                project.Apellido = cliente.Apellido;
                project.FechaNacimiento = cliente.FechaNacimiento;
                project.Direccion = cliente.Direccion;
                project.Telefono = cliente.Telefono;
                project.CorreoElectronico = cliente.CorreoElectronico;

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