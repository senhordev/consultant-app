using System;
using System.Collections.Generic;

namespace API
{
    public partial class Faturas
    {
        public Faturas()
        {
            Apontamentosfatura = new HashSet<Apontamentosfatura>();
        }

        public uint IdFatura { get; set; }
        public uint IdConsultor { get; set; }
        public uint IdProjeto { get; set; }
        public uint IdCliente { get; set; }
        public double? NumValorTotal { get; set; }
        public DateTime? DatRegistro { get; set; }
        public DateTime? DatAlteracao { get; set; }
        public uint? IdUsuario { get; set; }
        public char SitFatura { get; set; }

        public Clientes IdClienteNavigation { get; set; }
        public Consultores IdConsultorNavigation { get; set; }
        public Projetos IdProjetoNavigation { get; set; }
        public ICollection<Apontamentosfatura> Apontamentosfatura { get; set; }
    }
}
