using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{

    // Tamplete padrão business
    public interface IBusiness
    {
        List<ICadastro> Buscar();    
        ICadastro Buscar(uint id);
        void Cadastrar(ICadastro c);
        void Alterar(ICadastro c);
        bool Deletar (uint id);
    }
}
    
