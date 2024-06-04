using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D_MVC.Models
{
    public class RegistrarVM
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "El tipo {0} no es válido")]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="No es correcta")]
        [Display(Name = "Confirmación")]
        public string ConfirmPassword { get; set; }


    }
}
