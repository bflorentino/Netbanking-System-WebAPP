using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.BindingModel
{
    public class LoginUsuarioBindingModel
    {
       [Display(Name = "Nombre de usuario")]
       [Required(ErrorMessage ="Agregue su nombre de usuario")]
       public string NombreUsuario { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Agregue la contraseña")]
        public string Password { get; set; }
    }
}
