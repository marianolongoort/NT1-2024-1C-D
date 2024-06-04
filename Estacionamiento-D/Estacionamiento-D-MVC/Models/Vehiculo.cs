using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D_MVC.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(6)]
        public string Patente { get; set; }

        //Prop Navegacional
        public List<ClienteVehiculo> ClientesVehiculos { get; set; }

    }
}
