using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.BindingModel
{
    public class ClientCreateBindingModel
    {
        [Required(ErrorMessage = "Ingrese la cedula del cliente")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El numero de cedula debe de ser de 11 numeros")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Dato invalido, se deben ingresar 11 digitos numericos")]
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

        [Display(Name = "Correo Electronico")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Correo Electronico invalido")]
        public string? CorreoElectronico { get; set; }
    }

    public class ClientEditBindingModel
    {
        [Required(ErrorMessage = "Ingrese la cedula del cliente")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El numero de cedula debe de ser de 11 numeros")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Dato invalido, se deben ingresar 11 digitos numericos")]
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

        [Display(Name = "Correo Electronico")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Correo Electronico invalido")]
        public string? CorreoElectronico { get; set; }
    }
}