using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Titulacion.Models
{
    public partial class RelacionGrupos
    {
        public int IdRelacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdGrupo { get; set; }

        public virtual Grupos IdGrupoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
