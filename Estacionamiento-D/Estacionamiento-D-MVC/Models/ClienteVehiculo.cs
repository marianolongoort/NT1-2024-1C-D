namespace Estacionamiento_D_MVC.Models
{
    public class ClienteVehiculo
    {
        //prop relacionales
        public int ClienteId { get; set; }

        public int VehiculoId { get; set; }

        //Prop Navegacional
        public Cliente Cliente { get; set; }

        public Vehiculo Vehiculo { get; set; }

    }
}
