using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace  API.Business
{
    public interface ICadastro
    {
        UInt32 Id { get ; set; }
        uint IdUsuario { get; set; }   
    }

}