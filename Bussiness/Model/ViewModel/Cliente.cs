using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.ViewModel
{
    public class Cliente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name ="Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        [Display(Name="Correo Electronico")]
        public string CorreoElectronico { get; set; }
    }
}