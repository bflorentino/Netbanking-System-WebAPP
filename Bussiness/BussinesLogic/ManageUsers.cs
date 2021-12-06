using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data;

namespace Bussiness.BussinesLogic
{
    public class ManageUsers
    {
        static readonly NetBanking_Sys_WebAppContext dbContext = Contexto.GetContexto().Ctxto;
        public static Usuario UserOnline { get; set; }
 
        public static bool AddNewUser(Model.BindingModel.UsersCreateBindingModel usuario)
        {
            try
            {
                if (IsUserCliente(usuario.Cedula))
                {
                    // Aplicacion de hash a la contraseña
                    var UPasswordHashed = PasswordEncrypter.Compute256Hash(usuario.PasswordHashed);
                    dbContext.Usuarios.Add(new Usuario
                    {
                        NombreUsuario = usuario.NombreUsuario,
                        PasswordHashed = UPasswordHashed,
                        IdRol = 2,
                        Cedula = usuario.Cedula,
                        RutaFoto = usuario.RutaFoto
                    }
                   );
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
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

        private static bool IsUserCliente(string cedula)
        {
            // Verificar que un usuario sea cliente del banco
            var usuario = dbContext.Clientes.Find(cedula);
            return usuario != null;
        }

        public static void LogoutApp()
        {
            UserOnline = null;
        }
    }
}