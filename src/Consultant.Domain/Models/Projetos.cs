using System;
using System.Collections.Generic;

namespace API
{
    public partial class Projetos
    {
        public Projetos()
        {
            Atividades = new HashSet<Atividades>();
            Faturas = new HashSet<Faturas>();
        }

        public uint IdProjeto { get; set; }
        public uint IdConsultor { get; set; }
        public uint IdGerente { get; set; }
        public uint IdCliente { get; set; }
        public string DesProjeto { get; set; }
        public DateTime? DatRegistro { get; set; }
        public DateTime? DatAlteracao { get; set; }
        public uint? IdUsuario { get; set; }
        public DateTime? DatConclusao { get; set; }
        public uint? NumTempoTotal { get; set; }

        public Clientes IdClienteNavigation { get; set; }
        public Consultores IdConsultorNavigation { get; set; }
        public Gerentes IdGerenteNavigation { get; set; }
        public ICollection<Atividades> Atividades { get; set; }
        public ICollection<Faturas> Faturas { get; set; }
    }
}
