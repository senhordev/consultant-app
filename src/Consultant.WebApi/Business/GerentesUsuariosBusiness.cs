using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class GerentesUsuariosCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuarioGerente { get; set; }
        public uint IdUsuario { get; set; }
    }

    public class GerentesUsuariosBusiness : IBusiness
    {
        MyDbContext db;
        
        public GerentesUsuariosBusiness () => db = new MyDbContext();
        public GerentesUsuariosBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var gerUsuarios = new List<ICadastro>();
            foreach (var g in db.Gerentesusuarios.ToList())
            {
                gerUsuarios.Add(
                    new GerentesUsuariosCadastro
                    {
                        Id = g.IdGerente,
                        IdUsuarioGerente  = g.IdUsuarioGerente,
                        IdUsuario = Convert.ToUInt32(g.IdUsuario)
                    }
                );
            }
            return gerUsuarios;
        }

        public ICadastro Buscar(uint Id)
        {
         var cadastro = db.Gerentesusuarios.Where(x => x.IdGerente == Id).FirstOrDefault();
         if (cadastro != null)
         {
            return new GerentesUsuariosCadastro
            {
                Id = cadastro.IdGerente,
                IdUsuarioGerente = cadastro.IdUsuarioGerente,
                IdUsuario = Convert.ToUInt32(cadastro.IdUsuario)
            };
         }
         else return null;
        }
        public void Cadastrar(ICadastro c)
        {
            var gerUsuario = (GerentesUsuariosCadastro) c;
            db.Gerentesusuarios.Add(
                new Gerentesusuarios
                {
                    IdGerente = gerUsuario.Id,
                    IdUsuarioGerente = gerUsuario.IdUsuarioGerente,
                    IdUsuario = gerUsuario.IdUsuario,
                    DatRegistro = DateTime.Now
                }
            );
        }

        public void Alterar(ICadastro c)
        {
            var gerUsuario = (GerentesUsuariosCadastro)c;
            var cadastro = db.Gerentesusuarios.Where(x=> x.IdGerente == c.Id).FirstOrDefault();
            if (cadastro != null)
            {
                cadastro.IdUsuarioGerente = gerUsuario.IdUsuarioGerente;
                cadastro.IdUsuario = gerUsuario.IdUsuario;
                cadastro.DatRegistro = DateTime.Now;
                db.Gerentesusuarios.Update(cadastro);
                db.SaveChanges();
            }
            else Cadastrar(c);

        }
        public bool Deletar (uint id)
        {
            var cadastro = db.Gerentesusuarios.Where(x => x.IdGerente == id).FirstOrDefault();
            if (cadastro != null)
            {
                db.Gerentesusuarios.Remove(cadastro);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}