using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Titulacion.Clases;
using Titulacion.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Titulacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Bool = false;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuarios userReci)
        {
            UsuarioCLS user = new UsuarioCLS();

            switch (user.Validar(userReci))
            {
                case 0:

                    var claimsAlumno = new List<Claim>
                    {
                        new Claim("Usuario", userReci.User),
                        new Claim("Contraseña", userReci.Pass),
                        new Claim(ClaimTypes.Role, "0")
                    };

                    var claimsIdentityAlumno = new ClaimsIdentity(claimsAlumno, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentityAlumno));

                    return RedirectToAction("Alumnos", "Administrador");                    
                case 1:
                    var claimsProfe = new List<Claim>
                    {
                        new Claim("Usuario", userReci.User),
                        new Claim("Contraseña", userReci.Pass),
                        new Claim(ClaimTypes.Role, "2")
                    };
                    var claimsIdentityProfesor = new ClaimsIdentity(claimsProfe, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentityProfesor));
                    return RedirectToAction("InicioProfesor", "Sesiones");
                case 2:
                    var claimsAdmin = new List<Claim>
                    {
                        new Claim("Usuario", userReci.User),
                        new Claim("Contraseña", userReci.Pass),
                        new Claim(ClaimTypes.Role, "1")
                    };
                    var claimsIdentityAdmin = new ClaimsIdentity(claimsAdmin, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentityAdmin));
                    return RedirectToAction("InicioAlumno", "Sesiones");
                default:
                    ViewBag.Bool = true;
                    ViewBag.Error = "Tu usuario y/o contraseña son incorrectos";
                    return View();
            }
        }

        [HttpGet]
        public IActionResult Register() {
            ViewBag.Bool = false;
            return View();
        }
        [HttpPost]
        public IActionResult Register(string IdUsuario, string Correo)
        {
            UsuarioCLS user = new UsuarioCLS();
            ViewBag.Bool = true;
            ViewBag.TodoFine = user.registro(IdUsuario, Correo);
            return View();
        }

        public async Task<IActionResult> Logout() {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login","Home");
        }

        public IActionResult Denegado() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
