using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.BindingModel
{
    public class TransferenciaBindingModel
    {
        [Required(ErrorMessage = "Debe de ingresar la cantidad de dinero a transferir")]
        public decimal Cantidad { get; set; }

        public string CuentaOrigen { get; set; }

        [Display(Name = "Numero de cuenta destino")]
        [StringLength(20, MinimumLength = 20, ErrorMessage = "El numero de cuenta debe ser de 20 numeros")]
        [RegularExpression("[0-9]{20}", ErrorMessage = "Dato invalido, se deben ingresar 20 digitos numericos")]
        [Required(ErrorMessage = "Debe de ingresar el numero de cuenta al que desea hacer la transferencia")]
        public string Cuenta  { get; set; }
    }
}