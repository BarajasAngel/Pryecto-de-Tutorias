using System;
using System.Collections.Generic;
using System.Linq;
using Titulacion.Models;

namespace Titulacion.Clases
{
    public class UsuarioCLS
    {
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
                    return Convert.ToInt32(user.Tipo);
                }
                catch (Exception)
                {

                    return -1;
                }
            }

        }
        public List<Profesor> listaProfesores() {
            using (TutoriasContext db = new TutoriasContext())
            {
                var listaProfesor = (from prof in db.Profesor
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
        public string registro(string boleta, string correo) {
            try
            {
                using (TutoriasContext db = new TutoriasContext())
                {
                    var id = db.Usuarios.Where(x => x.User == boleta).First();
                    var comprobar = db.Alumno.Where(x => x.IdUsuario == id.IdUsuario).First();
                    comprobar.Correo = correo;
                    id.Visibilidad = true;
                    db.SaveChanges();
                    CorreoCLS enviar = new CorreoCLS(correo);
                    return enviar.smtpCorreo(); 
                }
            }
            catch (Exception)
            {
                return "Hubo un error";
            }            
        } 
    }
}