
namespace Estacionamiento_D_MVC.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Direccion Direccion { get; set; }

    }
}
