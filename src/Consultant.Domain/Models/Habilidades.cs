using System;
using System.Collections.Generic;

namespace API
{
    public partial class Habilidades
    {
        public Habilidades()
        {
            Consultoreshabilidades = new HashSet<Consultoreshabilidades>();
        }

        public uint IdHabilidades { get; set; }
        public string DesHabilidade { get; set; }
        public DateTime? DatRegistro { get; set; }
        public uint? IdUsuario { get; set; }

        public ICollection<Consultoreshabilidades> Consultoreshabilidades { get; set; }
    }
}
