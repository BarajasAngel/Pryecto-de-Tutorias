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
    public class SesionesController : Controller
    {
        UsuarioCLS obj = new UsuarioCLS();
        public IActionResult InicioAlumno()
        {
            List<Profesor> listaProfesor = obj.listaProfesores();            
            return View(listaProfesor);
        }
        public IActionResult TutoriasRegistradas() { 
            return View();
        }
    }
}
