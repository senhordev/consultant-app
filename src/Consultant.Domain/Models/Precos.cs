using System;
using System.Collections.Generic;

namespace API
{
    public partial class Precos
    {
        public uint IdPreco { get; set; }
        public uint IdConsultor { get; set; }
        public double? NumValorHora { get; set; }
        public DateTime? DatRegistro { get; set; }
        public DateTime? DatAlteracao { get; set; }
        public uint? IdUsuario { get; set; }

        public Consultores IdConsultorNavigation { get; set; }
    }
}
