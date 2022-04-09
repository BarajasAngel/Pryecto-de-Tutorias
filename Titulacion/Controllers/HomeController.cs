using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Titulacion.Clases;
using Titulacion.Models;

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
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuarios userReci)
        {
            UsuarioCLS user = new UsuarioCLS();

            switch (user.Validar(userReci))
            {
                case 0:
                    return View();
                case 1:
                    return View();
                case 2:
                    return RedirectToAction("InicioAlumno", "Sesiones");
                default:
                    return View();
            }
        }
        [HttpGet]
        public IActionResult Register() { 
            return View();
        }
        [HttpPost]
        public IActionResult Register(string IdUsuario, string Correo)
        {
            UsuarioCLS user = new UsuarioCLS();
            ViewBag.TodoFine = user.registro(IdUsuario, Correo);
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
