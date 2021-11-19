using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bussiness.BussinesLogic
{
    public class AdmClientes
    {
        public static void CreateCliente(Model.BindingModel.ClientCreateBindingModel cliente) 
        {
            Data.NetBanking_Sys_WebAppContext dbContext = new Data.NetBanking_Sys_WebAppContext();

            dbContext.Add(new Data.Cliente
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
    }
}
