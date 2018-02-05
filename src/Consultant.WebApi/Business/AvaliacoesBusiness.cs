using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class AvaliacoesCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuario { get; set; }
        public uint IdCliente { get; set; }
        public uint IdConsultor { get; set; }
        public string Avaliacao { get; set; }
        public uint Rating { get; set; }

    }

    public class AvaliacoesBusiness : IBusiness
    {
        MyDbContext db;
        
        public AvaliacoesBusiness () => db = new MyDbContext();
        public AvaliacoesBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var avaliacoes = new List<ICadastro>();
            foreach (var a in db.Avaliacao.ToList())
            {
                avaliacoes.Add(
                    new AvaliacoesCadastro
                    {
                        Id = a.IdAvaliacao,
                        IdConsultor = a.IdConsultor,
                        IdCliente = (uint) a.IdCliente,
                        Avaliacao = a.DesAvaliacao,
                        Rating = (uint) a.NumRating
                    }
                );
            }
            return avaliacoes;
        }

        public ICadastro Buscar(uint Id)
        {
            var cadastro = db.Avaliacao.Where(x=> x.IdAvaliacao == Id).FirstOrDefault();
            if (cadastro != null)
            {
                return new AvaliacoesCadastro
                {
                    Id = cadastro.IdAvaliacao,
                    IdConsultor = cadastro.IdConsultor,
                    IdCliente = (uint) cadastro.IdCliente,
                    Avaliacao = cadastro.DesAvaliacao,
                    Rating = (uint) cadastro.NumRating
                };
            }
            else return null;
        }

        public void Cadastrar(ICadastro c)
        {
            var a = (AvaliacoesCadastro)c;
            db.Avaliacao.Add(
                new Avaliacao
                {
                    IdAvaliacao = a.Id,
                    IdCliente = a.IdCliente,
                    IdConsultor = a.IdConsultor,
                    IdUsuario = a.IdUsuario,
                    DesAvaliacao = a.Avaliacao,
                    NumRating = a.Rating,
                    DatRegistro = DateTime.Now,
                    DatAlteracao = DateTime.Now
                }
            );

        }

        public void Alterar(ICadastro c)
        {
            var a = (AvaliacoesCadastro)c;
            var cadastro = db.Avaliacao.Where(x=> x.IdAvaliacao == a.Id).FirstOrDefault();
            if (cadastro != null)
            {
                cadastro.IdCliente = a.IdCliente;
                cadastro.IdConsultor = a.IdConsultor;
                cadastro.IdUsuario = a.IdUsuario;
                cadastro.DesAvaliacao = a.Avaliacao;
                cadastro.NumRating = a.Rating;
                cadastro.DatRegistro = DateTime.Now;
                cadastro.DatAlteracao = DateTime.Now;
                db.Avaliacao.Update(cadastro);
            }
            else Cadastrar(c);
        }
        public bool Deletar (uint id)
        {
            var cadastro = db.Avaliacao.Where(x=> x.IdAvaliacao == id).FirstOrDefault();
            if (cadastro != null)
            {
                db.Avaliacao.Remove(cadastro);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}