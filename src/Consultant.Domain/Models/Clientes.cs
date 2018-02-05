using System;
using System.Collections.Generic;

namespace API
{
    public partial class Clientes
    {
        public Clientes()
        {
            Avaliacao = new HashSet<Avaliacao>();
            Clientesusuarios = new HashSet<Clientesusuarios>();
            Faturas = new HashSet<Faturas>();
            Projetos = new HashSet<Projetos>();
        }

        public uint IdCliente { get; set; }
        public string DesCliente { get; set; }
        public uint? NumCnpj { get; set; }
        public DateTime? DatRegistro { get; set; }
        public uint? IdUsuario { get; set; }
        public DateTime? DatAlteracao { get; set; }

        public ICollection<Avaliacao> Avaliacao { get; set; }
        public ICollection<Clientesusuarios> Clientesusuarios { get; set; }
        public ICollection<Faturas> Faturas { get; set; }
        public ICollection<Projetos> Projetos { get; set; }
    }
}
