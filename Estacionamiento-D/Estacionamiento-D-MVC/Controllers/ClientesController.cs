using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estacionamiento_D_MVC.Data;
using Estacionamiento_D_MVC.Models;

namespace Estacionamiento_D_MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly MiBaseDeDatos _miDb;

        public ClientesController(MiBaseDeDatos context)
        {
            _miDb = context;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            var primerClienteEnDb = _miDb.Clientes.FirstOrDefault(
                                         c => c.Apellido == "Marmol"
                                         );

            var clientesEnDb = _miDb.Clientes                                        
                                        .OrderBy(clt => clt.Apellido)
                                            .ThenBy(clt => clt.Nombre)
                                        ;
            
            var clientesEnDbPicapi = _miDb.Clientes
                                            .Include(clt => clt.Direccion)
                                            .Where(clt => clt.Apellido == "Picapiedra"
                                             //   && clt.Nombre == "Pedro"
                                            )
                                            //.Take(2)
                                            ;

            return View(clientesEnDb);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _miDb.Clientes
                                        .Include(c => c.Direccion)
                                        .FirstOrDefaultAsync(m => m.Id == id);


            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            Cliente cliente = new Cliente()
            {
                Cuil = 20223334440,
                Nombre = "Pedro",
                Apellido = "Picapiedra",
                Email = "pedro@ort.edu.ar",
                AccessFailedCount = 0,
                Dia = DateOnly.FromDateTime(DateTime.Today)
            };            

            return View(cliente);
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cuil,Nombre,Apellido,Email,Dia,Hora,Password,Id,UserName,NormalizedUserName,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _miDb.Clientes.Add(cliente);
                await _miDb.SaveChangesAsync();
                return RedirectToAction("Create","Direcciones");
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _miDb.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cuil,Nombre,Apellido,Email,Dia,Hora,Password,Id,UserName,NormalizedUserName,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(cliente);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _miDb.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _miDb.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _miDb.Clientes.Remove(cliente);
            }

            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _miDb.Clientes.Any(e => e.Id == id);
        }
    }
}
