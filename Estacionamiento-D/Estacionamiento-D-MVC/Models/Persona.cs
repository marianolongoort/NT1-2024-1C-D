
using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D_MVC.Models
{
    public class Persona
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(25,MinimumLength = 5,ErrorMessage = "El campo {0} debe tener como minimo {2} y como maximmo {1}")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(5)]
        [MaxLength(25)]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage ="El tipo {0} no es válido")]
        [Display(Name ="Correo")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Dia { get; set; }


        [DataType(DataType.Time)]
        public TimeOnly Hora { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Prop Navegacional
        public Direccion Direccion { get; set; }

    }
}
