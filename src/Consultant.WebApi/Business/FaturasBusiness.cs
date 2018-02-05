using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class FaturasCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdConsultor { get; set; }
        public uint IdProjeto { get; set; }
        public uint IdCliente { get; set; }
        public double? ValorTotal { get; set; }
        public char situacao { get; set; }
        public uint IdUsuario { get; set; }
    }

    public class FaturasBusiness : IBusiness
    {
        MyDbContext db;
        
        public FaturasBusiness () => db = new MyDbContext();
        public FaturasBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var faturas = new List<ICadastro>();
            foreach (var fatura in db.Faturas.ToList())
            {
                faturas.Add(
                    new FaturasCadastro
                    {
                        Id = fatura.IdFatura,
                        IdCliente = fatura.IdCliente,
                        IdConsultor = fatura.IdConsultor,
                        IdProjeto = fatura.IdProjeto,
                        ValorTotal = fatura.NumValorTotal,
                        situacao = fatura.SitFatura,
                        IdUsuario = Convert.ToUInt32(fatura.IdUsuario)
                    }
                );
            }
            return faturas;
        }

        public ICadastro Buscar(uint Id)
        {
            var c = db.Faturas.Where(x => x.IdFatura == Id).FirstOrDefault();
            if (c != null)
            {
                return new FaturasCadastro
                {
                    Id = c.IdFatura,
                    IdCliente = c.IdCliente,
                    IdConsultor = c.IdConsultor,
                    IdProjeto = c.IdProjeto,
                    ValorTotal = c.NumValorTotal,
                    situacao = c.SitFatura,
                    IdUsuario = Convert.ToUInt32(c.IdUsuario)
                };

            }
            else return null;

        }

        public void Cadastrar(ICadastro c)
        {
            var fatura = (FaturasCadastro) c;
            db.Faturas.Add(
                new Faturas 
                {
                    IdFatura = fatura.Id,
                    IdProjeto = fatura.IdProjeto,
                    IdCliente = fatura.IdCliente,
                    IdConsultor = fatura.IdConsultor,
                    NumValorTotal = fatura.ValorTotal,
                    SitFatura = fatura.situacao,
                    DatRegistro = DateTime.Now,
                    DatAlteracao = DateTime.Now,
                    IdUsuario = fatura.IdUsuario
                }
            );

        }

        public void Alterar(ICadastro c)
        {
            var fatura = (FaturasCadastro) c;
            var cadastro = db.Faturas.Where(x => x.IdFatura == c.Id).FirstOrDefault();
            if (cadastro != null)
            {
                cadastro.IdProjeto = fatura.IdProjeto;
                cadastro.IdCliente = fatura.IdCliente;
                cadastro.IdConsultor = fatura.IdConsultor;
                cadastro.NumValorTotal = fatura.ValorTotal;
                cadastro.SitFatura = fatura.situacao;
                cadastro.DatRegistro = DateTime.Now;
                cadastro.DatAlteracao = DateTime.Now;
                cadastro.IdUsuario = fatura.IdUsuario;
                db.Faturas.Update(cadastro);
                db.SaveChanges();
            }
            else Cadastrar(c);

        }
        public bool Deletar(uint id)
        {
            var cadastro = db.Faturas.Where(x => x.IdFatura == id).FirstOrDefault();
            if (cadastro != null)
            {
                db.Faturas.Remove(cadastro);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}