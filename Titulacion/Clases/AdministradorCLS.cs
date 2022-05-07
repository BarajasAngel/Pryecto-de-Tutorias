using System;
using System.Collections.Generic;
using System.Linq;
using Titulacion.Models;
namespace Titulacion.Clases
{
    public class AdministradorCLS
    {
        public List<Alumno> MostrarALumnos() {
            using (TutoriasContext db = new TutoriasContext())
            {
                var listaAlumnos = (from alm in db.Alumno                                    
                                    select new Alumno
                                    {
                                        IdAlumno = alm.IdAlumno,
                                        IdUsuario = alm.IdUsuario,
                                        Nombre = alm.Nombre,
                                        ApellidoPat = alm.ApellidoPat,
                                        ApellidoMat = alm.ApellidoMat,
                                        Correo = alm.Correo,
                                        Grupo = alm.Grupo,
                                        Tutoria = alm.Tutoria
                                    }).ToList();

                List<Alumno> listaAlumnosVisibles = new List<Alumno>();
                for (int i = 0; i < listaAlumnos.Count; i++)
                {
                    var usuarios = db.Usuarios.Where(x => x.IdUsuario == listaAlumnos[i].IdUsuario).First();
                    if (usuarios.Visibilidad) {
                        listaAlumnosVisibles.Add(listaAlumnos[i]);
                    }
                }
                return listaAlumnosVisibles;
            }
        }
        public bool ModificarAlumno(Alumno alumno) {
            try
            {
                using (TutoriasContext db = new TutoriasContext())
                {
                    Alumno oAlumno = db.Alumno.Where(x => x.IdAlumno == alumno.IdAlumno).First();
                    oAlumno.Nombre = alumno.Nombre.ToUpper();
                    oAlumno.ApellidoPat = alumno.ApellidoPat.ToUpper();
                    oAlumno.ApellidoMat = alumno.ApellidoMat.ToUpper();
                    oAlumno.Correo = alumno.Correo;
                    oAlumno.Grupo = alumno.Grupo.ToUpper();
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool EliminarAlumno(int idAlumno) {
            using (TutoriasContext db = new TutoriasContext())
            {
                try
                {
                    Alumno oAlumno = db.Alumno.Where(x => x.IdAlumno == idAlumno).First();
                    Usuarios oUsuario = db.Usuarios.Where(x => x.IdUsuario == oAlumno.IdUsuario).First();
                    oAlumno.Correo = null;
                    oAlumno.Tutoria = false;
                    oUsuario.Visibilidad = false;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }                                
            }
        }
        public List<Profesor> MostrarProfesor()
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                var listaProfesores = (from prof in db.Profesor
                                    select new Profesor
                                    {
                                        IdProfesor = prof.IdProfesor,
                                        IdUsuario = prof.IdUsuario,
                                        Nombre = prof.Nombre,
                                        ApellidoPat = prof.ApellidoPat,
                                        ApellidoMat = prof.ApellidoMat,
                                        Correo = prof.Correo,
                                        HorasTutoria = prof.HorasTutoria,
                                        HorasTotales = prof.HorasTotales,
                                    }).ToList();
                List<Profesor> listaProfesorVisibles = new List<Profesor>();
                for (int i = 0; i < listaProfesores.Count; i++)
                {
                    var usuarios = db.Usuarios.Where(x => x.IdUsuario == listaProfesores[i].IdUsuario).First();
                    if (usuarios.Visibilidad)
                    {
                        listaProfesorVisibles.Add(listaProfesores[i]);
                    }
                }
                return listaProfesorVisibles;
            }
        }
        public bool ModificarProfesor(Profesor profesor) {
            try
            {
                using (TutoriasContext db = new TutoriasContext())
                {
                    Profesor oProfesor = db.Profesor.Where(x => x.IdProfesor == profesor.IdProfesor).First();
                    oProfesor.Nombre = profesor.Nombre.ToUpper();
                    oProfesor.ApellidoPat = profesor.ApellidoPat.ToUpper();
                    oProfesor.ApellidoMat = profesor.ApellidoMat.ToUpper();
                    oProfesor.Correo = profesor.Correo;
                    oProfesor.HorasTutoria = profesor.HorasTutoria;
                    oProfesor.HorasTotales = profesor.HorasTotales;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool EliminarProfesor(int idProfesor)
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                try
                {
                    Profesor oProfesor = db.Profesor.Where(x => x.IdProfesor == idProfesor).First();
                    Usuarios oUsuario = db.Usuarios.Where(x => x.IdUsuario == oProfesor.IdUsuario).First();
                    List<Inscripcion> oinscriopcion = db.Inscripcion.Where(x => x.IdProfesor == idProfesor).ToList();
                    for (int i = 0; i < oinscriopcion.Count; i++)
                    {
                        Alumno oAlumno = db.Alumno.Where(x => x.IdAlumno == oinscriopcion[i].IdAlumno).First();
                        oAlumno.Tutoria = false;
                    }
                    oProfesor.Correo = null;
                    oProfesor.HorasTutoria = 0;
                    oProfesor.HorasTotales = 0;
                    oUsuario.Visibilidad = false;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
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

