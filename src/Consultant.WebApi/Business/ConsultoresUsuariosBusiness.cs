using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class ConsultoresUsuariosCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuarioConsultor { get; set; }
        public uint IdUsuario { get; set; }
    }

    public class ConsultoresUsuariosBusiness : IBusiness
    {
        MyDbContext db;
        
        public ConsultoresUsuariosBusiness () => db = new MyDbContext();
        public ConsultoresUsuariosBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var conusuarios = new List<ICadastro>();
            foreach (var c in db.Consultoresusuarios.ToList())
            {
                conusuarios.Add(
                    new ConsultoresUsuariosCadastro
                    {
                        Id = c.IdConsultor,
                        IdUsuario = Convert.ToUInt32(c.IdUsuario),
                        IdUsuarioConsultor = c.IdUsuarioConsultor
                    }
                );
            }
            return conusuarios;
        }

        public ICadastro Buscar(uint Id)
        {
            var c = db.Consultoresusuarios.Where (x => x.IdConsultor == Id).FirstOrDefault();
            if (c != null)
            {
                return new ConsultoresUsuariosCadastro 
                {
                     Id = c.IdConsultor,
                     IdUsuario = Convert.ToUInt32(c.IdUsuario), 
                     IdUsuarioConsultor = c.IdUsuarioConsultor
                };
            }
            else return null;
        }

        public void Cadastrar(ICadastro c)
        {
            var cadastro = (ConsultoresUsuariosCadastro)c;
            db.Consultoresusuarios.Add(
                new Consultoresusuarios
                {
                    IdConsultor = cadastro.Id,
                    IdUsuarioConsultor = cadastro.IdUsuarioConsultor,
                    IdUsuario = cadastro.IdUsuario,
                    DatRegistro = DateTime.Now
                }
            );
        }

        public void Alterar(ICadastro c)
        {
            var cadastro = (ConsultoresUsuariosCadastro)c;
            var conusuario = db.Consultoresusuarios.Where(x => x.IdConsultor == c.Id).FirstOrDefault();
            if (conusuario != null)
            {
                conusuario.IdUsuarioConsultor = cadastro.IdUsuarioConsultor;
                conusuario.DatRegistro = DateTime.Now;
                conusuario.IdUsuario = cadastro.IdUsuario;
                db.Consultoresusuarios.Update(conusuario);
                db.SaveChanges();
            }
            else Cadastrar(c);

        }
        public bool Deletar (uint id)
        {
            var c = db.Consultoresusuarios.Where(x => x.IdConsultor == id).FirstOrDefault();
            if (c != null)
            {
                db.Consultoresusuarios.Remove(c);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}