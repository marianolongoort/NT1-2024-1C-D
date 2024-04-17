
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamiento_D_MVC.Models
{
    public class Persona : IdentityUser<int>

    {

        //public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener como minimo {2} y como maximmo {1}")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(5)]
        [MaxLength(25)]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "El tipo {0} no es válido")]
        [Display(Name = "Correo")]
        public override string Email
        {
            get { return base.Email; }
            set { base.Email = value; }
        }

        [DataType(DataType.Date)]
        public DateOnly Dia { get; set; }


        [DataType(DataType.Time)]
        public TimeOnly Hora { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Prop Navegacional
        public Direccion Direccion { get; set; }

        //Propiedad computada o calculada
        public string NombreCompleto
        {
            get
            {
                return $"{Apellido} - {Nombre}";
            }            
        }

    }
}
