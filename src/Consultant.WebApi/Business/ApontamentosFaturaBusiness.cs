using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class ApontamentoFaturaCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuario { get; set; }
        public uint IdApontamento { get; set; }
        public uint IdFatura { get; set; }
        public double? ValorApontamento { get; set; }
    }

    public class ApontamentosFaturaBusiness: IBusiness
    {
        MyDbContext db;
        public ApontamentosFaturaBusiness() => db = new MyDbContext();
        public ApontamentosFaturaBusiness(MyDbContext c) => db = c;
        public List<ICadastro> Buscar()
        {
            var apontamentosFatura = new List<ICadastro>();
            foreach (var af in db.Apontamentosfatura.ToList())
            {
                apontamentosFatura.Add
                (
                    new ApontamentoFaturaCadastro
                    {
                        Id = af.IdApontamentoFatura,
                        IdApontamento = af.IdApontamento,
                        IdFatura = af.IdFatura,
                        ValorApontamento = af.NumValorApontamento
                    }
                );
            }
            return apontamentosFatura;
        }

        public ICadastro Buscar(uint Id)
        {
            var cadastro = db.Apontamentosfatura.Where(x => x.IdApontamentoFatura == Id).FirstOrDefault();
            if (cadastro != null)
            {
                return new ApontamentoFaturaCadastro
                {
                    Id = cadastro.IdApontamentoFatura,
                    IdApontamento = cadastro.IdApontamento,
                    IdFatura = cadastro.IdFatura,
                    ValorApontamento = cadastro.NumValorApontamento
                };
            }
            else return null;
        }

        public void Cadastrar(ICadastro c)
        {
            var af = (ApontamentoFaturaCadastro) c;
            db.Apontamentosfatura.Add(
                new Apontamentosfatura
                {
                    IdApontamento = af.IdApontamento,
                    IdFatura = af.IdFatura,
                    IdUsuario = af.IdUsuario,
                    DatRegistro = DateTime.Now,
                    NumValorApontamento = af.ValorApontamento
                }
            );
            db.SaveChanges();
        }

        public void Alterar(ICadastro c)
        {
            var af = (ApontamentoFaturaCadastro) c;
            var cadastro = db.Apontamentosfatura.Where(x => x.IdApontamentoFatura == af.Id).FirstOrDefault();

            if (cadastro != null)
            {
                cadastro.IdApontamento = af.IdApontamento;
                cadastro.IdFatura = af.IdFatura;
                cadastro.DatRegistro = DateTime.Now;
                cadastro.IdUsuario = af.IdUsuario;
                cadastro.NumValorApontamento = af.ValorApontamento;
                db.Apontamentosfatura.Update(cadastro);
                db.SaveChanges();
            }
            else Cadastrar(c);
        }
        public bool Deletar (uint id)
        {
            var cadastro = db.Apontamentosfatura.Where(x => x.IdApontamentoFatura == id).FirstOrDefault();
            if (cadastro != null)
            {
                db.Apontamentosfatura.Remove(cadastro);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}