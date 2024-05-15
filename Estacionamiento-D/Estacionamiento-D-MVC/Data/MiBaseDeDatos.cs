using Estacionamiento_D_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Estacionamiento_D_MVC.Data
{
    public class MiBaseDeDatos : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public MiBaseDeDatos(DbContextOptions options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //La PK - El Id compuesto - La Key
            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv => new { cv.ClienteId,cv.VehiculoId});

            //la navegación de un clientevehiculo con respecto a un cliente
            modelBuilder.Entity<ClienteVehiculo>().HasOne(cv => cv.Cliente)
                                                    .WithMany(clt => clt.ClientesVehiculos)
                                                    .HasForeignKey(cv => cv.ClienteId);

            //la navegación de un clientevehiculo con respecto a un vehiculo
            modelBuilder.Entity<ClienteVehiculo>().HasOne(cv => cv.Vehiculo)
                                                    .WithMany(v => v.ClientesVehiculos)
                                                    .HasForeignKey(cv=>cv.VehiculoId);

            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");

            //modelBuilder.Entity<Direccion>().HasKey(d => d.Id);



        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<ClienteVehiculo> ClientesVehiculos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }


        //todas las demas propiedades, de los modelos que quiero persistir.

    }
}
