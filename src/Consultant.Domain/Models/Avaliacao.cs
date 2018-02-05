using System;
using System.Collections.Generic;

namespace API
{
    public partial class Avaliacao
    {
        public uint IdAvaliacao { get; set; }
        public uint IdConsultor { get; set; }
        public uint? IdCliente { get; set; }
        public string DesAvaliacao { get; set; }
        public uint? NumRating { get; set; }
        public DateTime? DatRegistro { get; set; }
        public DateTime? DatAlteracao { get; set; }
        public uint? IdUsuario { get; set; }

        public Clientes IdClienteNavigation { get; set; }
        public Consultores IdConsultorNavigation { get; set; }
    }
}
