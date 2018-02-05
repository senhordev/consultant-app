using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class ConsultorCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuario { get; set; }
        public string Nome { get; set; }           
    }

    public class ConsultoresBusiness : IBusiness
    {
        private MyDbContext db;

        public ConsultoresBusiness() => db = new MyDbContext();
        public ConsultoresBusiness(MyDbContext c) => db = c; 
        public List<ICadastro> Buscar()
        {
            var consultores = new List<ICadastro>();
            foreach (var consultor in db.Consultores.ToList())
            {
                consultores.Add(
                    new ConsultorCadastro
                    {
                        Id = consultor.IdConsultor,
                        Nome = consultor.DesConsultor
                    });
            }
            return consultores;
        }  
        public ICadastro Buscar(uint id)
        {
            var c = db.Consultores.Where(x => x.IdConsultor == id).FirstOrDefault();

            if (c != null) 
            {
                return new ConsultorCadastro { Id = c.IdConsultor, Nome = c.DesConsultor };
            }
            else return null;
        }
        public void Cadastrar(ICadastro c)
        {
            var consultor = (ConsultorCadastro) c;
            Consultores cadastro = new Consultores 
            {
                DesConsultor = consultor.Nome,
                DatRegistro = DateTime.Now,
                DatAlteracao = DateTime.Now,
                IdUsuario = consultor.IdUsuario
            };

            db.Consultores.Add(cadastro);
            db.SaveChanges();
        }
        public void Alterar(ICadastro c)
        {
            var consultor = (ConsultorCadastro) c;
            var cadastro = db.Consultores.Where(x => x.IdConsultor == consultor.Id).FirstOrDefault();

            if (cadastro != null)
            {
                cadastro.DesConsultor = consultor.Nome;
                cadastro.DatAlteracao = DateTime.Now;
                cadastro.IdUsuario = consultor.IdUsuario;
                db.Consultores.Update(cadastro);
                db.SaveChanges();
            }
            else 
            {
                Cadastrar(c);
            }
        }
        public bool Deletar (uint id)
        {
            var consultor = db.Consultores.Where(x => x.IdConsultor == id).FirstOrDefault();

            if (consultor != null)
            {
                db.Consultores.Remove(consultor);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
     
    }

}