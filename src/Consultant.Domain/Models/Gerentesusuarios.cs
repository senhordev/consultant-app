using System;
using System.Collections.Generic;

namespace API
{
    public partial class Gerentesusuarios
    {
        public uint IdGerente { get; set; }
        public uint IdUsuarioGerente { get; set; }
        public DateTime? DatRegistro { get; set; }
        public uint? IdUsuario { get; set; }

        public Gerentes IdGerenteNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
