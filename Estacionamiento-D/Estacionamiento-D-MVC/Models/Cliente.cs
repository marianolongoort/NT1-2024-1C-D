using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D_MVC.Models
{
    public class Cliente : Persona
    {
     
        public long Cuil { get; set; }


        //Prop Navegacional
        public List<ClienteVehiculo> ClientesVehiculos { get; set; }




        //Prop Nav
        public List<Telefono> Telefonos { get; set; }
    }
}
