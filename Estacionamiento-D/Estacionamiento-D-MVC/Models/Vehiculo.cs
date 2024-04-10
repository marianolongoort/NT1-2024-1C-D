namespace Estacionamiento_D_MVC.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Patente { get; set; }

        //Prop Navegacional
        public List<ClienteVehiculo> ClientesVehiculos { get; set; }

    }
}
