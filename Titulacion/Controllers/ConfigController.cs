using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Titulacion.Clases;

namespace Titulacion.Controllers
{

    public class ConfigController : Controller
    {
        General generic = new General();
        UsuarioCLS user = new UsuarioCLS();
        [HttpGet]
        [Authorize(Roles = "Alumno")]
        public IActionResult Alumno()
        {
            ViewBag.Boleta = generic.Boleta;
            ViewBag.Nombre = user.AlumnoConfig()[0];
            ViewBag.Correo = user.AlumnoConfig()[1];
            ViewBag.Grupo = user.AlumnoConfig()[2];
            ViewBag.Bool = false;
            return View();
        }
        [HttpPost]
        public IActionResult Alumno(string Boleta, string Pass) {
            ViewBag.Boleta = generic.Boleta;
            ViewBag.Nombre = user.AlumnoConfig()[0];
            ViewBag.Correo = user.AlumnoConfig()[1];
            ViewBag.Grupo = user.AlumnoConfig()[2];
            ViewBag.Error = user.UpdatePassAlumno(Boleta, Pass);
            ViewBag.Bool = true;
            return View();
        }
        [HttpPost]
        public IActionResult EmailAlumno(string Boleta, string Correo) {
            ViewBag.Error = user.UpdateEmailAlumno(Boleta, Correo);
            ViewBag.Bool = true;
            return RedirectToAction("Alumno");
        }
        [HttpGet]
        [Authorize(Roles = "Profesor")]
        public IActionResult Profesor() {
            ViewBag.Info = new UsuarioCLS().ProfeConfig();
            ViewBag.Usuario = generic.Boleta;
            ViewBag.Bool = false;
            return View();
        }
        [HttpPost]
        public IActionResult Profesor(string Usuario, string Pass) {
            ViewBag.Info = new UsuarioCLS().ProfeConfig();
            ViewBag.Usuario = generic.Boleta;
            ViewBag.Error = user.UpdatePassProfe(Usuario, Pass); 
            ViewBag.Bool = true;
            return View();
        }
        [HttpPost]
        public IActionResult EmailProfesor(string Usuario, string Correo) {
            ViewBag.Error = user.UpdateEmailProfe(Usuario, Correo);
            ViewBag.Bool = true;
            return RedirectToAction("Profesor");
        }
    }
}
