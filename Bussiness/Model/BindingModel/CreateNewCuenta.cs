using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.BindingModel
{
    public class CreateNewCuenta
    {
        [Display(Name = "Numero de cuenta")]
        [Required(ErrorMessage ="Se require un número de cuenta")]
        [StringLength(20, MinimumLength =20, ErrorMessage ="El numero de cuenta debe ser de 20 numeros")]
        [RegularExpression("[0-9]{20}", ErrorMessage ="Dato invalido, se deben ingresar 20 digitos numericos")]
        public string NumeroCuenta { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Ingrese la cedula del cliente")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El numero de cedula debe de ser de 11 numeros")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Dato invalido, se deben ingresar 11 digitos numericos")]
        public string Cedula { get; set; }
    }
}