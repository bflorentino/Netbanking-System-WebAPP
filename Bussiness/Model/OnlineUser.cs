using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Bussiness.Model
{
    public class OnlineUser
    {
        /// <summary>
        /// El objetivo de esta clase es almacenar el usuario que esta en linea en un momento determinado
        /// </summary>
        public static Usuario OnlineUsuario { get; set; }
        public  OnlineUser(Usuario usario)
        {
            OnlineUsuario = usario;
        }
    }
}