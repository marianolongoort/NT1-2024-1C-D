using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamiento_D_MVC.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="La {0} es requeridiiiiisima")]
        [StringLength(100,MinimumLength = 5)]
        public string Calle { get; set; }

        public int Numero { get; set; }

        public int CodPostal { get; set; }

        //propiedad Relacional

        public int PersonaId { get; set; }

        //Propiedad Navegacional
        public Persona Persona { get; set; }

    }
}
