using System.Collections.Generic;
using System.Linq;
using Titulacion.Models;

namespace Titulacion.Clases
{
    public class UsuarioCLS
    {
        public bool Validar(Usuarios userReci)
        {
            using (TutoriasContext db = new TutoriasContext())
            {
                string pass = General.cifrarDatos(userReci.Pass);
                int nveces = db.Usuarios.Where(x => x.User == userReci.User && x.Pass == pass).Count();

                if (nveces > 0)
                {   
                    return true;
                }
                else
                {
                    return false;
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
                                     Visibilidad = prof.Visibilidad
                                 }).ToList();
                return listaProfesor;
            }
            
        }
    }
}