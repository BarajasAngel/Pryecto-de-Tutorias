using System;
using System.Collections.Generic;
using System.Linq;
using Titulacion.Models;

namespace Titulacion.Clases
{
    public class UsuarioCLS
    {
        private static bool tutoria;
        private static string nombre;

        public bool Tutoria { get => tutoria; set => tutoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        General generic = new General();

        public int Validar(Usuarios userReci)
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                string pass = General.cifrarDatos(userReci.Pass);
                try
                {
                    var user = db.Usuarios.Where(x => x.User == userReci.User && x.Pass == pass).First();

                    if (!user.Visibilidad)
                    {
                        return -1;
                    }
                    if (Convert.ToInt32(user.Tipo) == 1)
                    {
                        generic.Boleta = user.User;
                    }
                    if (Convert.ToInt32(user.Tipo) == 2)
                    {
                        var alumn = db.Alumno.Where(x => x.IdUsuario == user.IdUsuario).First();
                        generic.Boleta = user.User;
                        Nombre = alumn.Nombre + " " + alumn.ApellidoPat + " " + alumn.ApellidoMat;
                        Tutoria = alumn.Tutoria;
                    }
                    return Convert.ToInt32(user.Tipo);
                }
                catch (Exception)
                {

                    return -1;
                }
            }

        }
        public List<Profesor> listaProfesores()
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                var getUser = db.Usuarios.Where(x => x.User == generic.Boleta).First();
                var getGrupo = db.Alumno.Where(x => x.IdUsuario == getUser.IdUsuario).First().Grupo;
                var listaProfesor = (from prof in db.Profesor
                                     where prof.Grupo == getGrupo
                                     select new Profesor
                                     {
                                         Nombre = prof.Nombre,
                                         ApellidoPat = prof.ApellidoPat,
                                         ApellidoMat = prof.ApellidoMat,
                                         HorasTutoria = prof.HorasTutoria,
                                     }).ToList();
                return listaProfesor;
            }

        }
        public string registro(string boleta, string correo)
        {
            try
            {
                using (TutoriasContext db = new TutoriasContext())
                {
                    var id = db.Usuarios.Where(x => x.User == boleta).First();
                    var getAlumno = db.Alumno.Where(x => x.IdUsuario == id.IdUsuario).First();

                    if (getAlumno.Correo != null)
                    {
                        return "Esta boleta ya cuenta con un correo asociado";
                    }
                    else
                    {
                        try
                        {
                            var getCorreo = db.Alumno.Where(x => x.Correo == correo).First();
                            return "El correo ya esta asociado a otra boleta, por favor intenta otro";
                        }
                        catch (Exception)
                        {
                            getAlumno.Correo = correo;
                            id.Visibilidad = true;

                            CorreoCLS enviar = new CorreoCLS(correo);
                            string contraseña = enviar.Generar_Contraseña();

                            id.Pass = General.cifrarDatos(contraseña);

                            db.SaveChanges();
                            return enviar.smtpCorreo(contraseña);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "Hubo un error";
            }
        }
        public bool RegistrarTutor(string boleta, string nomProfe)
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                //Primero se debe obtener al alumno y al profesor, despues al alumno se le habilitara la tutoria
                //Mientras que al profesor se le descontaran horas en funion al alumno inscrito
                //Al alumno se le habilitara la vista Tutorias
                //Para despues crearse un registro de la tabla inscripcion con los datos del alumno y profesor
                //En el registro de inscripcion se generara un folio Aleatorio al momento

                try
                {
                    Inscripcion inscrip = new Inscripcion();
                    var us = db.Usuarios.Where(x => x.User == boleta).First();
                    var alm = db.Alumno.Where(x => x.IdUsuario == us.IdUsuario).First();
                    string[] aux = nomProfe.Split(' ');
                    var prof = db.Profesor.Where(x => x.Nombre == aux[0]).First();
                    prof.HorasTutoria--;
                    alm.Tutoria = true;
                    inscrip.IdProfesor = prof.IdProfesor;
                    inscrip.IdAlumno = alm.IdAlumno;
                    inscrip.Fecha = DateTime.Now.Date;
                    inscrip.Folio = General.Folio(alm);
                    db.Inscripcion.Add(inscrip);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public List<Alumno> listaAlumnos()
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                var idProfesor = db.Usuarios.Where(x => x.User == generic.Boleta).First().IdUsuario;
                var Profesor = db.Profesor.Where(x => x.IdUsuario == idProfesor).First().IdProfesor;
                List<Inscripcion> inscri = db.Inscripcion.Where(x => x.IdProfesor == Profesor).ToList();
                List<Alumno> alumnosRegistrados = new List<Alumno>();
                Alumno alumno = new Alumno();
                for (int i = 0; i < inscri.Count; i++)
                {
                    var alm = db.Alumno.Where(x => x.IdAlumno == inscri[i].IdAlumno).First();
                    alumnosRegistrados.Add(alm);
                }
                return alumnosRegistrados;
            }
        }
        public string[] AlumnoConfig()
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                var getAccount = db.Usuarios.Where(x => x.User == generic.Boleta).First();
                var getAlumno = db.Alumno.Where(x => x.IdUsuario == getAccount.IdUsuario).First();
                string[] info = { getAlumno.Nombre + " " + getAlumno.ApellidoPat + " " + getAlumno.ApellidoMat, getAlumno.Correo, getAlumno.Grupo };
                return info;
            }
        }
        public string UpdatePassAlumno(string Boleta, string Pass)
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                try
                {
                    var getUsuario = db.Usuarios.Where(x => x.User == Boleta).First();
                    getUsuario.Pass = General.cifrarDatos(Pass);
                    db.SaveChanges();
                    return "Contraseña cambiada con exito";
                }
                catch (Exception)
                {
                    return "Tuvimos un problema para poder cambiar tu contraseña";
                }
            }
        }
        public string UpdateEmailAlumno(string Boleta, string Correo)
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                try
                {
                    var getUsuario = db.Usuarios.Where(x => x.User == Boleta).First();
                    var getAlumno = db.Alumno.Where(x => x.IdUsuario == getUsuario.IdUsuario).First();

                    CorreoCLS enviar = new CorreoCLS(Correo);

                    getAlumno.Correo = Correo;
                    db.SaveChanges();
                    return enviar.smtpCorreo();
                }
                catch (Exception)
                {
                    return "Tuvimos un problema para poder cambiar tu Correo";
                }
            }
        }
        public string[] ProfeConfig()
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                var getAccount = db.Usuarios.Where(x => x.User == generic.Boleta).First();
                var getProfesor = db.Profesor.Where(x => x.IdUsuario == getAccount.IdUsuario).First();
                string[] info = { getProfesor.Nombre + " " +
                        getProfesor.ApellidoPat + " " + getProfesor.ApellidoMat, getProfesor.Correo,
                        getProfesor.Grupo, getProfesor.HorasTutoria.ToString(),
                        getProfesor.HorasTotales.ToString()};
                return info;

            }
        }
        public string UpdatePassProfe(string Usuario, string Pass)
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                try
                {
                    var getUsuario = db.Usuarios.Where(x => x.User == Usuario).First();
                    getUsuario.Pass = General.cifrarDatos(Pass);
                    db.SaveChanges();
                    return "Contraseña cambiada con exito";
                }
                catch (Exception)
                {
                    return "Tuvimos un problema para poder cambiar tu contraseña";
                }
            }
        }
        public string UpdateEmailProfe(string Boleta, string Correo)
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                try
                {
                    var getUsuario = db.Usuarios.Where(x => x.User == Boleta).First();
                    var getProfe = db.Profesor.Where(x => x.IdUsuario == getUsuario.IdUsuario).First();

                    CorreoCLS enviar = new CorreoCLS(Correo);

                    getProfe.Correo = Correo;
                    db.SaveChanges();
                    return enviar.smtpCorreo();
                }
                catch (Exception)
                {
                    return "Tuvimos un problema para poder cambiar tu Correo";
                }
            }
        }
    }
}