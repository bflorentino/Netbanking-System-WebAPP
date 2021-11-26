using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClientesCuenta = new HashSet<ClientesCuenta>();
            ClientesPrestamos = new HashSet<ClientesPrestamo>();
            ClientesTarjeta = new HashSet<ClientesTarjeta>();
        }

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public virtual ICollection<ClientesCuenta> ClientesCuenta { get; set; }
        public virtual ICollection<ClientesPrestamo> ClientesPrestamos { get; set; }
        public virtual ICollection<ClientesTarjeta> ClientesTarjeta { get; set; }
    }
}
