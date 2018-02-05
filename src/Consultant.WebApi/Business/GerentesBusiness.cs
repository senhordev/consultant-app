using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class GerenteCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuario { get; set; }
        public string Nome { get; set; }
    }

    public class GerentesBusiness : IBusiness
    {

        MyDbContext db;

        public GerentesBusiness() => db = new MyDbContext();
        public GerentesBusiness(MyDbContext c) => db = c;

        public List<ICadastro> Buscar()
        {
            List<ICadastro> gerentes = new List<ICadastro>();
            foreach (var gerente in db.Gerentes.ToList())
            {
                gerentes.Add
                (
                    new GerenteCadastro
                    {
                        Id = gerente.IdGerente,
                        Nome = gerente.DesGerente
                    }
                );
            }
            return gerentes;
        }

        public ICadastro Buscar(uint Id)
        {
            var cadastro = db.Gerentes.Where(x => x.IdGerente == Id).FirstOrDefault();
            if (cadastro != null)
            {
                var gerente = new GerenteCadastro
                {
                    Id = cadastro.IdGerente,
                    Nome = cadastro.DesGerente
                };
                return gerente;
            }
            else return null;
        }

        public void Cadastrar(ICadastro c)
        {
            var gerente = (GerenteCadastro) c;
            db.Gerentes.Add(
                new Gerentes
                {
                    DesGerente = gerente.Nome,
                    DatRegistro = DateTime.Now,
                    DatAlteracao = DateTime.Now,
                    IdUsuario = gerente.IdUsuario
                }
            );
        }

        public void Alterar(ICadastro c)
        {
            var gerente = (GerenteCadastro) c;
            var cadastro = db.Gerentes.Where(x => x.IdGerente == gerente.Id).FirstOrDefault();
            if (cadastro != null)
            {
                cadastro.DesGerente = gerente.Nome;
                cadastro.DatAlteracao = DateTime.Now;
                cadastro.IdUsuario = gerente.IdUsuario;
                db.Gerentes.Add(cadastro);
                db.SaveChanges();
            }
            else
            {
                Cadastrar(c);
            }
        }
        public bool Deletar (uint id)
        {
            var cadastro = db.Gerentes.Where(x => x.IdGerente == id).FirstOrDefault();
            if (cadastro != null)
            {
                db.Gerentes.Remove(cadastro);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}