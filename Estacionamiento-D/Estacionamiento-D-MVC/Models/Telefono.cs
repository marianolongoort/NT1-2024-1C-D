namespace Estacionamiento_D_MVC.Models
{
    public class Telefono
    {
        public int Id { get; set; }
        public int Caracteristica { get; set; }
        public int Numero { get; set; }

        //Prop Relacional
        public int ClienteId { get; set; }
        //Prop Nav
        public Cliente Cliente { get; set; }
    }
}
