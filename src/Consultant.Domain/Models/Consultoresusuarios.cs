using System;
using System.Collections.Generic;

namespace API
{
    public partial class Consultoresusuarios
    {
        public uint IdConsultor { get; set; }
        public uint IdUsuarioConsultor { get; set; }
        public DateTime? DatRegistro { get; set; }
        public uint? IdUsuario { get; set; }

        public Consultores IdConsultorNavigation { get; set; }
        public Usuarios IdUsuarioConsultorNavigation { get; set; }
    }
}
