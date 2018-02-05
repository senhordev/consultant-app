using System;
using System.Collections.Generic;

namespace API
{
    public partial class Consultores
    {
        public Consultores()
        {
            Avaliacao = new HashSet<Avaliacao>();
            Consultoreshabilidades = new HashSet<Consultoreshabilidades>();
            Consultoresusuarios = new HashSet<Consultoresusuarios>();
            Faturas = new HashSet<Faturas>();
            Precos = new HashSet<Precos>();
            Projetos = new HashSet<Projetos>();
        }

        public uint IdConsultor { get; set; }
        public string DesConsultor { get; set; }
        public uint? IdUsuario { get; set; }
        public DateTime? DatRegistro { get; set; }
        public DateTime? DatAlteracao { get; set; }

        public ICollection<Avaliacao> Avaliacao { get; set; }
        public ICollection<Consultoreshabilidades> Consultoreshabilidades { get; set; }
        public ICollection<Consultoresusuarios> Consultoresusuarios { get; set; }
        public ICollection<Faturas> Faturas { get; set; }
        public ICollection<Precos> Precos { get; set; }
        public ICollection<Projetos> Projetos { get; set; }
    }
}
