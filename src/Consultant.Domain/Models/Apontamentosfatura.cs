using System;
using System.Collections.Generic;

namespace Consultant.Domain.Models
{
    public partial class Apontamentosfatura
    {
        public uint IdApontamentoFatura { get; set; }
        public uint IdApontamento { get; set; }
        public uint IdFatura { get; set; }
        public double? NumValorApontamento { get; set; }
        public DateTime? DatRegistro { get; set; }
        public uint? IdUsuario { get; set; }

        public Apontamentos IdApontamentoNavigation { get; set; }
        public Faturas IdFaturaNavigation { get; set; }
    }
}
