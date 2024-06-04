using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D_MVC.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "El tipo {0} no es válido")]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Recordarme { get; set; }


    }
}
