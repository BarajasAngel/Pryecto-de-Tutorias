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
        [HttpGet]
        public IActionResult InicioAlumno()
        {
            List<Profesor> listaProfesor = obj.listaProfesores();
            ViewBag.Tutoria = obj.Tutoria;
            return View(listaProfesor);
        }
        [HttpPost]
        public IActionResult InicioAlumno(string IdUsuario, string nomProfe)
        {
            ViewBag.Tutoria = obj.RegistrarTutor(IdUsuario, nomProfe);
            List<Profesor> listaProfesor = obj.listaProfesores();
            if (ViewBag.Tutoria)
            {
                ViewBag.Respuesta = "Todo Bien";
            }
            else
            {
                ViewBag.Respuesta = "Todo Mal";
            }
            return View(listaProfesor);
        }
        [HttpPost]
        public IActionResult Comprobante() {
            ComprobanteCLS compro = new ComprobanteCLS();
            MemoryStream documento = compro.GenerarComprobante();
            documento.Seek(0, SeekOrigin.Begin);
            return File(documento,"application/pdf");
        }
        public IActionResult InicioProfesor() {
            List<Alumno> alumno = obj.listaAlumnos();
            ViewBag.Lista = obj.listaGrupos();
            return View(alumno);
        }

    }
}
