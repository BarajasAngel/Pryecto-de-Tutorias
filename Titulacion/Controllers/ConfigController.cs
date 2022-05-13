using Microsoft.AspNetCore.Mvc;
using Titulacion.Clases;

namespace Titulacion.Controllers
{
    public class ConfigController : Controller
    {
        General generic = new General();
        UsuarioCLS user = new UsuarioCLS();
        [HttpGet]
        public IActionResult Alumno()
        {            
            ViewBag.Boleta = generic.Boleta;
            ViewBag.Nombre = user.AlumnoConfig()[0];
            ViewBag.Correo = user.AlumnoConfig()[1];
            ViewBag.Grupo = user.AlumnoConfig()[2];
            return View();
        }
        [HttpPost]
        public IActionResult UpdatePassAlumno(string Boleta, string Pass) {
            user.UpdatePassAlumno(Boleta, Pass);
            return RedirectToAction("Alumno");
        }
        [HttpGet]
        public IActionResult Profesor() {
            ViewBag.Info = new UsuarioCLS().ProfeConfig();
            ViewBag.Usuario = generic.Boleta;
            return View();
        }
        [HttpPost]
        public IActionResult UpdatePassProfesor(string Usuario, string Pass) {
            user.UpdatePassProfe(Usuario,Pass)
            return RedirectToAction("Profesor");
        }
    }
}
