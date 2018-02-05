using System;
using System.Collections.Generic;

namespace API
{
    public partial class Consultoreshabilidades
    {
        public uint IdConsultor { get; set; }
        public uint IdHabilidades { get; set; }
        public DateTime? DatRegistro { get; set; }
        public uint? IdUsuario { get; set; }

        public Consultores IdConsultorNavigation { get; set; }
        public Habilidades IdHabilidadesNavigation { get; set; }
    }
}
