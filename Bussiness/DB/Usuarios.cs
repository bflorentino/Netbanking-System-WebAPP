using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.DB
{
    internal class Usuarios
    {
        public string NombreUsuario { get; set; }
        public string PasswordHashed { get; set; }
        public int IdRol { get; set; }
        public string RutaFoto { get; set; }

        public virtual Role IdRolNavigation { get; set; }
    }
}
