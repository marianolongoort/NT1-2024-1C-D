using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D_MVC.Models
{
    public class Empleado : Persona
    {
        [Required]
        [MaxLength(50)]
        public string Legajo { get; set; }
    }
}
