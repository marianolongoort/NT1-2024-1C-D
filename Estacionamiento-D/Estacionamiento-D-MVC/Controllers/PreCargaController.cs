using Estacionamiento_D_MVC.Data;
using Estacionamiento_D_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento_D_MVC.Controllers
{
    public class PreCargaController : Controller
    {
        private readonly MiBaseDeDatos _context;
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly string _passwordDefault = "Password1!";


        public PreCargaController(
            MiBaseDeDatos context,
            UserManager<Persona> userManager,
            RoleManager<Rol> roleManager
            )
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public IActionResult Seed()
        {
            //Regenerar la DB
            RegenerarDB();

            //Crear role
            CrearRoles().Wait();
            //Crear Admin
            
            //Crear Cliente
            CrearClientes().Wait();

            //CrearDirecciones
            CrearDirecciones();

            //Crear Vehiculo
            CrearVehiculos();
            
            //Crear Relacion ClienteVehiculo
            CrearClientesVehiculos();

            CrearEmpleados().Wait();


            return RedirectToAction("Index", "Home", new { mensaje = "Db Pre-Cargada" });
        }

        private async Task CrearEmpleados()
        {
            Empleado emp1 = new Empleado()
            {
                Nombre = "Pablo",
                Apellido = "Marmol",
                Legajo = "A1345556",
                Email = "pablo@ort.edu.ar",
                UserName = "pablo@ort.edu.ar"
            };

            var result1 = await _userManager.CreateAsync(emp1, _passwordDefault);

            if (result1.Succeeded)
            {
                await _userManager.AddToRoleAsync(emp1, Misc.EmpleadoRoleName);
            }
        }

        private void CrearDirecciones()
        {
            Direccion dir1 = new Direccion() { 
                Calle = "Cor",
                Numero = 2222,
                CodPostal=1425,
                PersonaId=1
            };
            _context.Direcciones.Add(dir1);
            _context.SaveChanges();

        }

        private void CrearClientesVehiculos()
        {
            _context.ClientesVehiculos.Add(
                new ClienteVehiculo() { ClienteId=1,VehiculoId=1}
                );
            _context.SaveChanges();
        }

        private void CrearVehiculos()
        {
            Vehiculo vh1 = new Vehiculo()
            {
                Patente = "III333",
            };
            _context.Vehiculos.Add(vh1);
            _context.SaveChanges();
        }

        private async Task CrearClientes()
        {
            Cliente clt1 = new Cliente() {
                Nombre="Pedro",
                Apellido="Picapiedra",
                Cuil=20223334440,
                Email="pedro@ort.edu.ar",
                UserName="pedro@ort.edu.ar"                
            };

             var result1 = await _userManager.CreateAsync(clt1,_passwordDefault);

            if (result1.Succeeded)
            {
                await _userManager.AddToRoleAsync(clt1,Misc.ClienteRoleName);
            }

        }

        public IActionResult RecreateDb() {
            RegenerarDB();
            return RedirectToAction("Index","Home",new { mensaje="Db regenerada"});
        }



        private void RegenerarDB()
        {
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();
        }

        private async Task CrearRoles()
        {            
            await _roleManager.CreateAsync(new Rol("Administrador"));
            await _roleManager.CreateAsync(new Rol(Misc.ClienteRoleName));
            await _roleManager.CreateAsync(new Rol(Misc.EmpleadoRoleName));
        }
    }
}
