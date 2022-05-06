using System;
using System.Collections.Generic;
using System.Linq;
using Titulacion.Models;
namespace Titulacion.Clases
{
    public class AdministradorCLS
    {
        public List<Alumno> MostrarALumnos() {
            using (TutoriasContext db =  new TutoriasContext())
            {
                var listaAlumnos = (from alm in db.Alumno
                                     select new Alumno
                                     {
                                         Nombre = alm.Nombre,
                                         ApellidoPat = alm.ApellidoPat,
                                         ApellidoMat = alm.ApellidoMat,
                                         Correo = alm.Correo,
                                         Grupo = alm.Grupo,
                                         Tutoria = alm.Tutoria
                                     }).ToList();
                return listaAlumnos;
            }            
        }
        public List<Profesor> MostrarProfesor()
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                var listaProfesores = (from prof in db.Profesor
                                    select new Profesor
                                    {
                                        Nombre = prof.Nombre,
                                        ApellidoPat = prof.ApellidoPat,
                                        ApellidoMat = prof.ApellidoMat,
                                        Correo = prof.Correo,
                                        HorasTutoria = prof.HorasTutoria,
                                        HorasTotales = prof.HorasTotales,
                                    }).ToList();
                return listaProfesores;
            }
        }
        public List<inscripcionCLS> MostrarInscripciones() {

            using (TutoriasContext db = new TutoriasContext())
            {
                
                List<Inscripcion> auxIncrip = db.Inscripcion.ToList();
                List<inscripcionCLS> listaInscripciones = new List<inscripcionCLS>();
            for (int i = 0; i < auxIncrip.Count; i++)
                {
                    inscripcionCLS inscrip = new inscripcionCLS();
                    
                    inscrip.Profesor = db.Profesor.Where(x => x.IdProfesor == auxIncrip[i].IdProfesor).First().ApellidoPat;
                    inscrip.Profesor += " " + db.Profesor.Where(x => x.IdProfesor == auxIncrip[i].IdProfesor).First().ApellidoMat;
                    inscrip.Profesor += " " + db.Profesor.Where(x => x.IdProfesor == auxIncrip[i].IdProfesor).First().Nombre;                    
                    inscrip.Alumno = db.Alumno.Where(x => x.IdAlumno == auxIncrip[i].IdAlumno).First().ApellidoPat;
                    inscrip.Alumno += " " + db.Alumno.Where(x => x.IdAlumno == auxIncrip[i].IdAlumno).First().ApellidoMat;
                    inscrip.Alumno += " " + db.Alumno.Where(x => x.IdAlumno == auxIncrip[i].IdAlumno).First().Nombre;
                    inscrip.Fecha = auxIncrip[i].Fecha;
                    inscrip.Folio = auxIncrip[i].Folio;
                    listaInscripciones.Add(inscrip);                    
                }
                return listaInscripciones;
            }            
        }
    }
}

