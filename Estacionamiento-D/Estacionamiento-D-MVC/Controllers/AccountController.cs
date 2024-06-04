using Estacionamiento_D_MVC.Data;
using Estacionamiento_D_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamiento_D_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly MiBaseDeDatos _midb;
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly SignInManager<Persona> _signInManager;

        public AccountController(
            MiBaseDeDatos midb,
            UserManager<Persona> userManager,
            RoleManager<Rol> roleManager,
            SignInManager<Persona> signInManager            
            )
        {
            this._midb = midb;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        #region Registrar

        //Ofrecer el formulario de registración
        public IActionResult Registrar()
        {
            return View();
        }

        //Procesar info del cliente para registralo
        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarVM clienteFormulario)
        {
            if (ModelState.IsValid)
            {
                //ok avanzo con la registración.
                Cliente cliente = new Cliente() { 
                    Email = clienteFormulario.Email,
                    UserName = clienteFormulario.Email
                };

                var resultCreateUser = await _userManager.CreateAsync(cliente,clienteFormulario.Password);

                if (resultCreateUser.Succeeded)
                {
                    //perfecto pude crear el usuario

                    await _signInManager.SignInAsync(cliente,false);

                    return RedirectToAction("Index", "Home");
                }
                //tratart el error
                
            }
            //tratamiento del error.

            return View(clienteFormulario);
        }


        #endregion

        #region Inicio y Cierre de sesión
        public IActionResult IniciarSesion()
        {
            bool estaAutenticado = User.Identity.IsAuthenticated;
            if (estaAutenticado) {
                return RedirectToAction("Index","Clientes");
            }
            return View();
        }

        //Procesar info del cliente para registralo
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {


                var resultSignIn = await _signInManager.PasswordSignInAsync(loginVM.Email,loginVM.Password,loginVM.Recordarme,false);

                if (resultSignIn.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                //tratart el error
                ModelState.AddModelError(string.Empty,"Inicio inválido");
                ModelState.AddModelError("Email", "Este correo no es válido");

            }
            //tratamiento del error.

            return View(loginVM);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }

        #endregion
    }
}
