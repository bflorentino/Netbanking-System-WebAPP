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
        public static Usuario UserOnline { get; set; }
 
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

       public static bool IsUserValid(Model.BindingModel.LoginUsuarioBindingModel usuario)
        {
            // Validad que un usuario exista dentro de la base de datos
            return GetUser(usuario) != null;
        }

        public static Usuario GetUser(Model.BindingModel.LoginUsuarioBindingModel usuario)
        {
            Usuario User = (from user in dbContext.Usuarios
                            where usuario.NombreUsuario == user.NombreUsuario
                            && user.PasswordHashed == PasswordEncrypter.Compute256Hash(usuario.Password)
                            select user).FirstOrDefault();

            return User;
        }

        public static void SetUserOnline(Model.BindingModel.LoginUsuarioBindingModel usuario)
        {
            Usuario user = GetUser(usuario);
            UserOnline = user;
        }
    }
}