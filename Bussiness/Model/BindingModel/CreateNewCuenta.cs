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
        public string NumeroCuenta { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

    }
}
