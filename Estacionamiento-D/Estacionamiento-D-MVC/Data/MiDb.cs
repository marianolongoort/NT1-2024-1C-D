using Estacionamiento_D_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Estacionamiento_D_MVC.Data
{
    public class MiDb : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public MiDb(DbContextOptions options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Estacionamiento_D_MVC.Models.Direccion> Direccion { get; set; }
        //todas las demas propiedades, de los modelos que quiero persistir.

    }
}
