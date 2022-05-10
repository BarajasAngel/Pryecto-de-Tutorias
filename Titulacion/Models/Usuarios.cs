using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Titulacion.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Alumno = new HashSet<Alumno>();
            AreaTutorias = new HashSet<AreaTutorias>();
            Profesor = new HashSet<Profesor>();
            RelacionGrupos = new HashSet<RelacionGrupos>();
        }

        public int IdUsuario { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public decimal Tipo { get; set; }
        public bool Visibilidad { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual ICollection<AreaTutorias> AreaTutorias { get; set; }
        public virtual ICollection<Profesor> Profesor { get; set; }
        public virtual ICollection<RelacionGrupos> RelacionGrupos { get; set; }
    }
}
