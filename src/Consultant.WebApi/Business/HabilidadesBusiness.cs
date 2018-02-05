using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class HabilidadesCadastro : ICadastro
    {
        public uint Id { get; set; }
        public string DesHabilidade { get; set; }
        public uint IdUsuario { get; set; }
    }

    public class HabilidadesBusiness : IBusiness
    {
        MyDbContext db;
        
        public HabilidadesBusiness () => db = new MyDbContext();
        public HabilidadesBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var habilidades = new List<ICadastro>();
            foreach (var habilidade in db.Habilidades.ToList())
            {
                habilidades.Add( 
                    new HabilidadesCadastro
                    {
                        Id = habilidade.IdHabilidades,
                        IdUsuario = Convert.ToUInt32(habilidade.IdUsuario),
                        DesHabilidade = habilidade.DesHabilidade
                    }
                );
            }
            return habilidades;
        }

        public ICadastro Buscar(uint Id)
        {
            var h = db.Habilidades.Where( x=> x.IdHabilidades ==  Id).FirstOrDefault();
            if (h != null)
            {
                return new HabilidadesCadastro
                {
                    Id = h.IdHabilidades,
                    IdUsuario = Convert.ToUInt32(h.IdUsuario),
                    DesHabilidade = h.DesHabilidade
                };
            }
            else return null;
        }

        public void Cadastrar(ICadastro c)
        {
            var habilidade = (HabilidadesCadastro)c;
            db.Habilidades.Add(
                new Habilidades
                {
                    DesHabilidade = habilidade.DesHabilidade,
                    IdUsuario = habilidade.IdUsuario,
                    DatRegistro = DateTime.Now
                }
            );
        }

        public void Alterar(ICadastro c)
        {
            var cadastro = db.Habilidades.Where(x => x.IdHabilidades == c.Id).FirstOrDefault();
            var habilidade = (HabilidadesCadastro) c;
            if (cadastro != null)
            {
                cadastro.DesHabilidade = habilidade.DesHabilidade;
                cadastro.IdUsuario = habilidade.IdUsuario;
                cadastro.DatRegistro = DateTime.Now;
                db.Habilidades.Update(cadastro);
                db.SaveChanges();
            }
            else Cadastrar(c);
        }
        public bool Deletar (uint id)
        {
            var h = db.Habilidades.Where( x=> x.IdHabilidades == id).FirstOrDefault();
            if (h != null)
            {
                db.Habilidades.Remove(h);
                db.SaveChanges();
                return true;
            }   
            else return false;
        }
    }

}