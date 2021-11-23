using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data;

namespace Bussiness.BussinesLogic
{
    public class ManageUsers
    {
        static readonly NetBanking_Sys_WebAppContext dbContext = new NetBanking_Sys_WebAppContext();
 
        public static void AddNewUser(Model.BindingModel.UsersCreateBindingModel usuario)
        {
            // Aplicacion de hash a la contraseña
            usuario.PasswordHashed = PasswordEncrypter.Compute256Hash(usuario.PasswordHashed);

            dbContext.Usuarios.Add(new Usuario
            {
                NombreUsuario = usuario.NombreUsuario,
                PasswordHashed = usuario.PasswordHashed,
                IdRol = 2,
               Cedula = usuario.Cedula,
                RutaFoto = usuario.RutaFoto
            }
           ); 
            dbContext.SaveChanges();
        }
    }
}