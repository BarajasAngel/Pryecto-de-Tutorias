using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Titulacion.Models
{
    public partial class Inscripcion
    {
        public int IdInscripcion { get; set; }
        public int IdProfesor { get; set; }
        public int IdAlumno { get; set; }
        public DateTime Fecha { get; set; }
        public int Folio { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}
