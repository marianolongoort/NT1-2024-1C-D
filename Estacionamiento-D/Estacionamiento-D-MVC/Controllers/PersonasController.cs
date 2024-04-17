using Estacionamiento_D_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamiento_D_MVC.Controllers
{
    public class PersonasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DameNombreCompleto(string nombre,string apellido = "TBD")
        {
            //proceso
            Persona persona = new Persona();
            persona.Nombre = nombre;
            persona.Apellido = apellido;

            return View(persona);
        }
    }
}
