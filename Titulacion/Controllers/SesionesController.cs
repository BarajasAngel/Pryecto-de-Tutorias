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
    public class SesionesController : Controller
    {
        UsuarioCLS obj = new UsuarioCLS();
        General generic = new General();
        [HttpGet]
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
        public FileResult Comprobante()
        {
            ComprobanteCLS compro = new ComprobanteCLS();
            MemoryStream documento = compro.GenerarComprobante();
            //documento.Seek(0, SeekOrigin.Begin);
            return File(documento.ToArray(), "application/pdf");
        }
        [HttpGet]
        public IActionResult InicioProfesor() {
            List<Alumno> alumno = obj.listaAlumnos();
            ViewBag.Lista = obj.listaGrupos();
            return View(alumno);
        }

    }
}
