using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.BindingModel
{
    public class UsersCreateBindingModel
    {
        [Required(ErrorMessage = "Se requiere agregar un nombre de usuario")]
        [Display(Name ="Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage ="Se requiere agregar una contraseña")]
        [Display(Name ="Contraseña")]
        public string PasswordHashed { get; set; }

        [Required(ErrorMessage = "Ingrese la cedula del cliente")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El numero de cedula debe de ser de 11 numeros")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Dato invalido, se deben ingresar 11 digitos numericos")]
        public string Cedula { get; set; }

        public string RutaFoto { get; set; }
    }
}
