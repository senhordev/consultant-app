using System;
using System.Collections.Generic;

namespace API
{
    public partial class Apontamentos
    {
        public Apontamentos()
        {
            Apontamentosfatura = new HashSet<Apontamentosfatura>();
        }

        public uint IdApontamento { get; set; }
        public uint IdAtividade { get; set; }
        public uint? IdConsultor { get; set; }
        public DateTime? DatInicio { get; set; }
        public DateTime? DatFim { get; set; }
        public DateTime? DatRegistro { get; set; }
        public string DesRegistro { get; set; }

        public Atividades IdAtividadeNavigation { get; set; }
        public ICollection<Apontamentosfatura> Apontamentosfatura { get; set; }
    }
}
