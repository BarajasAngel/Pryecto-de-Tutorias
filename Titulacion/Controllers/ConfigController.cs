using Microsoft.AspNetCore.Mvc;
using Titulacion.Clases;

namespace Titulacion.Controllers
{
    public class ConfigController : Controller
    {
        General generic = new General();
        UsuarioCLS user = new UsuarioCLS();
        
        public IActionResult Alumno()
        {            
            ViewBag.Boleta = generic.Boleta;
            ViewBag.Nombre = user.AlumnoConfig()[0];
            ViewBag.Correo = user.AlumnoConfig()[1];
            ViewBag.Grupo = user.AlumnoConfig()[2];
            return View();
        }
        public IActionResult UpdatePassAlumno(string Boleta, string Pass) {
            user.UpdatePassAlumno(Boleta, Pass);
            return RedirectToAction("Alumno");
        }
        public IActionResult Profesor() {
            return View();
        }
    }
}
