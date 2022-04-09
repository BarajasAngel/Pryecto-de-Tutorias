using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Titulacion.Models
{
    public partial class AreaTutorias
    {
        public int IdArea { get; set; }
        public int IdUsuario { get; set; }
        public string NombreArea { get; set; }
        public string Administrador { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
