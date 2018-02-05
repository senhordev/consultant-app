using System;
using System.Collections.Generic;

namespace API
{
    public partial class Gerentes
    {
        public Gerentes()
        {
            Gerentesusuarios = new HashSet<Gerentesusuarios>();
            Projetos = new HashSet<Projetos>();
        }

        public uint IdGerente { get; set; }
        public string DesGerente { get; set; }
        public DateTime? DatRegistro { get; set; }
        public DateTime? DatAlteracao { get; set; }
        public uint? IdUsuario { get; set; }

        public ICollection<Gerentesusuarios> Gerentesusuarios { get; set; }
        public ICollection<Projetos> Projetos { get; set; }
    }
}
