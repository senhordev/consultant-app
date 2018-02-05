using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class ProjetosCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdConsultor { get; set; }
        public uint IdGerente { get; set; }
        public uint IdCliente { get; set; }
        public string DesProjeto { get; set; }
        public DateTime DataConclusao { get; set; }
        public uint TempoTotal { get; set; }
        public uint IdUsuario { get; set; }
    }

    public class ProjetosBusiness : IBusiness
    {
        MyDbContext db;
        
        public ProjetosBusiness () => db = new MyDbContext();
        public ProjetosBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var projetos = new List<ICadastro>();
            foreach (var p in db.Projetos.ToList())
            {
                projetos.Add(
                    new ProjetosCadastro
                    {
                        Id = p.IdProjeto,
                        IdCliente = p.IdCliente,
                        IdConsultor = p.IdConsultor,
                        IdGerente = p.IdGerente,
                        DesProjeto = p.DesProjeto,
                        IdUsuario = Convert.ToUInt32(p.IdUsuario),
                        DataConclusao = Convert.ToDateTime(p.DatConclusao),
                        TempoTotal = Convert.ToUInt32(p.NumTempoTotal)
                    }
                );
            }
            return projetos;
        }

        public ICadastro Buscar(uint Id)
        {
            var p = db.Projetos.Where(x => x.IdProjeto == Id).FirstOrDefault();
            if (p != null)
            {
                return new ProjetosCadastro
                {
                    Id = p.IdProjeto,
                    IdCliente = p.IdCliente,
                    IdConsultor = p.IdConsultor,
                    IdGerente = p.IdGerente,
                    DesProjeto = p.DesProjeto,
                    IdUsuario = Convert.ToUInt32(p.IdUsuario),
                    DataConclusao = Convert.ToDateTime(p.DatConclusao),
                    TempoTotal = Convert.ToUInt32(p.NumTempoTotal)
                };
            }
            else return null;

        }

        public void Cadastrar(ICadastro c)
        {
            var p = (ProjetosCadastro) c;
            db.Projetos.Add(
                new Projetos
                {
                    IdConsultor = p.IdConsultor,
                    IdGerente = p.IdGerente,
                    IdCliente = p.IdCliente,
                    DesProjeto = p.DesProjeto,
                    DatRegistro = DateTime.Now,
                    DatAlteracao = DateTime.Now,
                    IdUsuario = p.IdUsuario,
                    DatConclusao = p.DataConclusao,
                    NumTempoTotal = p.TempoTotal
                }
            );
        }

        public void Alterar(ICadastro c)
        {
            var p = (ProjetosCadastro)c;
            var cadastro = db.Projetos.Where(x=> x.IdProjeto == p.Id).FirstOrDefault();
            if (cadastro != null)
            {
                cadastro.IdConsultor = p.IdConsultor;
                cadastro.IdCliente = p.IdCliente;
                cadastro.IdGerente = p.IdGerente;
                cadastro.DesProjeto = p.DesProjeto;
                cadastro.DatConclusao = p.DataConclusao;
                cadastro.DatAlteracao = DateTime.Now;
                cadastro.IdUsuario = p.IdUsuario;
                cadastro.NumTempoTotal = p.TempoTotal;
                db.Projetos.Update(cadastro);
                db.SaveChanges();
            }
            else Cadastrar(c);
        }
        public bool Deletar (uint id)
        {
            var p = db.Projetos.Where(x=> x.IdProjeto == id).FirstOrDefault();
            if (p != null)
            {
                db.Projetos.Remove(p);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}