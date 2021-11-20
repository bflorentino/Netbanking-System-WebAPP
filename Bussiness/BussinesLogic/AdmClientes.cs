using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Bussiness.BussinesLogic
{
    public class AdmClientes
    {
        /// <summary>
        /// 
        /// </summary>
       static NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
        public static void CreateCliente(Model.BindingModel.ClientCreateBindingModel cliente) 
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
        }

        public static List<Model.ViewModel.Cliente> GetClientes()
        {
            var clientes = (from cliente in dbContext.Clientes
                                select cliente).ToList();

            var listaClientesViewModel = new List<Model.ViewModel.Cliente>() ;

            foreach(Cliente cliente in clientes)
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
    }
}
