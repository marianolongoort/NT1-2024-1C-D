namespace Estacionamiento_D_MVC.Models
{
    public class Direccion
    {
        public int Id { get; set; }

        public string Calle { get; set; }

        public int Numero { get; set; }

        //propiedad Relacional
        public int PersonaId { get; set; }

        //Propiedad Navegacional
        public Persona Persona { get; set; }

    }
}
