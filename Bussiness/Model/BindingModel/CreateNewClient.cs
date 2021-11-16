using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.BindingModel
{
    public class CreateNewClient
    {
        [Required(ErrorMessage ="Se require agregar la cédula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Se require agregar el nombre del cliente")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se require agregar el apellido del cliente")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Se require agregar la fecha de nacimiento del cliente")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Se require agregar la direccion del cliente")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Se require agregar el número de teléfono del cliente")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Se require agregar la cédula")]
        [Display(Name = "Correo Electronico")]
        public string? CorreoElectronico { get; set; }
    }
}