using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Titulacion.Models
{
    public partial class Grupos
    {
        public int IdGrupo { get; set; }
        public string Grupo { get; set; }
        public int IdProfesor { get; set; }

        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}
