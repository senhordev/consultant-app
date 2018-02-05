using System;
using System.Collections.Generic;

namespace API
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Clientesusuarios = new HashSet<Clientesusuarios>();
            Consultoresusuarios = new HashSet<Consultoresusuarios>();
            Gerentesusuarios = new HashSet<Gerentesusuarios>();
        }

        public uint IdUsuario { get; set; }
        public string DesUsuario { get; set; }
        public DateTime? DatRegistro { get; set; }
        public DateTime? DatAlteracao { get; set; }
        public string DesSenha { get; set; }
        public string DesEmail { get; set; }

        public ICollection<Clientesusuarios> Clientesusuarios { get; set; }
        public ICollection<Consultoresusuarios> Consultoresusuarios { get; set; }
        public ICollection<Gerentesusuarios> Gerentesusuarios { get; set; }
    }
}
