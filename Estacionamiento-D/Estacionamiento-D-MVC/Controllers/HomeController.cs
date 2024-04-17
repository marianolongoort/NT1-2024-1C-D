using Estacionamiento_D_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Estacionamiento_D_MVC.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            //inicio

            //Toda la logica necesaria para obtener, procesar, etc.

            //definir tipo de respuesta al cliente.
            return View();
        }

        public ActionResult Privacy2()
        {
            if (true)
            {
                return View();
            }

            return View("test");
        }

        public int Sumar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

    }
}
