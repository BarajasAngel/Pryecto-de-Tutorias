using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Titulacion.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Inscripcion = new HashSet<Inscripcion>();
        }

        public int IdAlumno { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string Correo { get; set; }
        public string Grupo { get; set; }
        public bool Tutoria { get; set; }
        public bool Visibilidad { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Inscripcion> Inscripcion { get; set; }
    }
}
