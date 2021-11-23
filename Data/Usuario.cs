using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Usuario
    {
        public string NombreUsuario { get; set; }
        public string PasswordHashed { get; set; }
        public string Cedula { get; set; }
        public int IdRol { get; set; }
        public string RutaFoto { get; set; }


        public virtual Cliente CedulaNavigation { get; set; }
        public virtual Role IdRolNavigation { get; set; }
    }
}
