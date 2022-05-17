using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Titulacion.Clases;
using Titulacion.Models;

namespace Titulacion.Controllers
{    
    [Authorize]
    public class SesionesController : Controller
    {
        UsuarioCLS obj = new UsuarioCLS();
        General generic = new General();
        
        [HttpGet]
        [Authorize(Roles = "Alumno")]
        public IActionResult InicioAlumno()
        {
            List<Profesor> listaProfesor = obj.listaProfesores();
            ViewBag.Tutoria = obj.Tutoria;
            ViewBag.Nombre = obj.Nombre;
            ViewBag.Boleta = generic.Boleta;
            return View(listaProfesor);
        }
        [HttpPost]
        public IActionResult InicioAlumno(string IdUsuario, string nomProfe)
        {
            ViewBag.Tutoria = obj.RegistrarTutor(IdUsuario, nomProfe);
            List<Profesor> listaProfesor = obj.listaProfesores();
            return View(listaProfesor);
        }        
        public IActionResult EliminarAlumno(string idAlumno) {
            return RedirectToAction("InicioAlumno");
        }
        [Authorize(Roles = "Alumno")]
        public FileResult Comprobante()
        {
            ComprobanteCLS compro = new ComprobanteCLS();
            FileStream documento =  compro.GenerarComprobante();
            return File(documento, "application/pdf");
        }
        [HttpGet]
        [Authorize(Roles = "Profesor")]
        public IActionResult InicioProfesor() {
            List<Alumno> alumno = obj.listaAlumnos();            
            return View(alumno);
        }

    }
}
