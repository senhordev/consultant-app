using System;
using System.Collections.Generic;

namespace API
{
    public partial class Atividades
    {
        public Atividades()
        {
            Apontamentos = new HashSet<Apontamentos>();
        }

        public uint IdAtividade { get; set; }
        public uint IdProjeto { get; set; }
        public string DesTitulo { get; set; }
        public string DesAtividade { get; set; }
        public DateTime? DatRegistro { get; set; }
        public DateTime? DatAlteracao { get; set; }
        public uint? IdUsuario { get; set; }

        public Projetos IdProjetoNavigation { get; set; }
        public ICollection<Apontamentos> Apontamentos { get; set; }
    }
}
