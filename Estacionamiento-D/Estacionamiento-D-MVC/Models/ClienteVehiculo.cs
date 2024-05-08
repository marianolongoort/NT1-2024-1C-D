using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D_MVC.Models
{
    public class ClienteVehiculo
    {
        //prop relacionales
        [Key]
        public int ClienteId { get; set; }

        [Key]
        public int VehiculoId { get; set; }

        //Prop Navegacional
        public Cliente Cliente { get; set; }

        public Vehiculo Vehiculo { get; set; }

    }
}
