using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness.Model.ViewModel
{
    public class Cuenta
    {
        [Display(Name="Numero de cuenta")]
        public string NumeroCuenta { get; set; }

        [Display(Name="Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name ="Balance de la cuenta")]
        public decimal Balance { get; set; }
    }
}