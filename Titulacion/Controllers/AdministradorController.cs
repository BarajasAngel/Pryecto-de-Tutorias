using Microsoft.AspNetCore.Mvc;
using Titulacion.Clases;
namespace Titulacion.Controllers
{
    public class AdministradorController : Controller
    {
        AdministradorCLS obj = new AdministradorCLS();
        public IActionResult Alumnos() {            
            return View(obj.MostrarALumnos());
        }
        public IActionResult Profesores() {
            return View(obj.MostrarProfesor());
        }
        public IActionResult Inscripciones() {
            return View(obj.MostrarInscripciones());
        }
    }
}
