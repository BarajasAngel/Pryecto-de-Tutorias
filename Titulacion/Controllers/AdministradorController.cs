using Microsoft.AspNetCore.Mvc;
using Titulacion.Clases;
namespace Titulacion.Controllers
{
    public class AdministradorController : Controller
    {
        AdministradorCLS obj = new AdministradorCLS();
        [HttpGet]
        public IActionResult Alumnos() {            
            return View(obj.MostrarALumnos());
        }
        [HttpPost]
        public IActionResult EliminarAlumno(string idAlumno)
        {
            obj.EliminarAlumno(int.Parse(idAlumno));
            return RedirectToAction("Alumnos");
        }
        public IActionResult Profesores() {
            return View(obj.MostrarProfesor());
        }
        [HttpPost]
        public IActionResult EliminarProfesor(string idProfesor)
        {
            obj.EliminarProfesor(int.Parse(idProfesor));
            return RedirectToAction("Profesores");
        }
        public IActionResult Inscripciones() {
            return View(obj.MostrarInscripciones());
        }
    }
}
