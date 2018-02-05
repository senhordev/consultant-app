using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class ConsultoresHabilidadesCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdHabilidade { get; set; }
        public uint IdUsuario { get; set; }
    }

    public class ConsultoresHabilidadesBusiness : IBusiness
    {
        MyDbContext db;
        
        public ConsultoresHabilidadesBusiness () => db = new MyDbContext();
        public ConsultoresHabilidadesBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var chabilidades = new List<ICadastro>();
            foreach (var c in db.Consultoreshabilidades.ToList())
            {
                chabilidades.Add(
                    new ConsultoresHabilidadesCadastro
                    {
                        Id = c.IdConsultor,
                        IdHabilidade = c.IdHabilidades,
                        IdUsuario = Convert.ToUInt32(c.IdUsuario)
                    }
                );
            }
            return chabilidades;
        }

        public ICadastro Buscar(uint Id)
        {
            var cadastro = db.Consultoreshabilidades.Where(x => x.IdConsultor == Id).FirstOrDefault();
            if (cadastro != null)
            {
                return new ConsultoresHabilidadesCadastro
                {
                    Id = cadastro.IdConsultor,
                    IdHabilidade = cadastro.IdHabilidades,
                    IdUsuario = Convert.ToUInt32(cadastro.IdUsuario)
                };
            }
            else return null;
        }

        public void Cadastrar(ICadastro c)
        {
            var ch = (ConsultoresHabilidadesCadastro) c;
            db.Consultoreshabilidades.Add(
                new Consultoreshabilidades
                {
                    IdConsultor = ch.Id,
                    IdHabilidades = ch.IdHabilidade,
                    IdUsuario = ch.IdUsuario,
                    DatRegistro = DateTime.Now
                }
            ); 
            
        }

        public void Alterar(ICadastro c)
        {
            var ch = (ConsultoresHabilidadesCadastro) c;
            var cadastro = db.Consultoreshabilidades.Where(x => x.IdConsultor == c.Id).FirstOrDefault();
            if (ch != null)
            {
                cadastro.IdHabilidades = ch.IdHabilidade;
                cadastro.DatRegistro = DateTime.Now;
                cadastro.IdUsuario = ch.IdUsuario;
                db.Consultoreshabilidades.Update(cadastro);
                db.SaveChanges();
            }
            else
            {
                Cadastrar(c);
            }

        }
        public bool Deletar (uint id)
        {
            var c = db.Consultoreshabilidades.Where(x => x.IdConsultor == id).FirstOrDefault();
            if (c != null)
            {
                db.Consultoreshabilidades.Remove(c);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}