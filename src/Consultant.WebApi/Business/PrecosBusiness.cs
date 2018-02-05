using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class PrecosCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdConsultor { get; set; }
        public double? ValorHora { get; set; }
        public uint IdUsuario { get; set; }
    }

    public class PrecosBusiness : IBusiness
    {
        MyDbContext db;
        
        public PrecosBusiness () => db = new MyDbContext();
        public PrecosBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var precos = new List<ICadastro>();
            foreach (var p in db.Precos.ToList())
            {
                precos.Add(
                    new PrecosCadastro
                    {
                        Id = p.IdPreco,
                        IdConsultor = p.IdConsultor,
                        ValorHora = p.NumValorHora,
                        IdUsuario = Convert.ToUInt32(p.IdUsuario)
                    }
                );
            }
            return precos;
        }

        public ICadastro Buscar(uint Id)
        {
            var preco = db.Precos.Where(x=> x.IdPreco == Id).FirstOrDefault();
            if (preco != null)
            {
                return new PrecosCadastro
                {
                    Id = preco.IdPreco,
                    IdConsultor = preco.IdConsultor,
                    IdUsuario = Convert.ToUInt32(preco.IdUsuario),
                    ValorHora = preco.NumValorHora
                };
            }   
            else return null;
        }

        public void Cadastrar(ICadastro c)
        {
            var p = (PrecosCadastro) c;
            db.Precos.Add(
                new Precos
                {
                    IdConsultor = p.IdConsultor,
                    NumValorHora = p.ValorHora,
                    IdUsuario = p.IdUsuario,
                    DatRegistro = DateTime.Now,
                    DatAlteracao = DateTime.Now
                }
            );
        }

        public void Alterar(ICadastro c)
        {
            var p = (PrecosCadastro)c;
            var cadastro = db.Precos.Where(x=> x.IdPreco == p.Id).FirstOrDefault();

            if (cadastro != null)
            {
                cadastro.IdConsultor = p.IdConsultor;
                cadastro.NumValorHora = p.ValorHora;
                cadastro.IdUsuario = p.IdUsuario;
                cadastro.DatAlteracao = DateTime.Now;
                db.Precos.Update(cadastro);
                db.SaveChanges();
            }
            else Cadastrar(c);
        }
        public bool Deletar (uint id)
        {
            var p = db.Precos.Where(x=> x.IdPreco == id).FirstOrDefault();
            if (p != null)
            {
                db.Precos.Remove(p);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}