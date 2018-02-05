using System;
using System.Collections.Generic;

namespace API
{
    public partial class Clientesusuarios
    {
        public uint IdCliente { get; set; }
        public uint IdUsuarioCliente { get; set; }
        public DateTime? DatRegistro { get; set; }
        public uint? IdUsuarios { get; set; }

        public Clientes IdClienteNavigation { get; set; }
        public Usuarios IdUsuarioClienteNavigation { get; set; }
    }
}
