using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class ApontamentosCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuario { get; set; }
        public uint IdAtividade { get; set; }
        public uint? IdConsultor { get; set; }
        public string Descricao { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }

    }

    public class ApontamentosBusiness : IBusiness
    {
        MyDbContext db;
        public ApontamentosBusiness() => db = new MyDbContext();
        public ApontamentosBusiness(MyDbContext c) => db = c;  
        public List<ICadastro> Buscar()
        {
            var apontamentos = new List<ICadastro>();
            foreach (var apontamento in db.Apontamentos.ToList())
            {
                apontamentos.Add(
                    new ApontamentosCadastro
                    {
                        Id = apontamento.IdApontamento,
                        IdConsultor = apontamento.IdConsultor,
                        IdAtividade = apontamento.IdAtividade,
                        Descricao = apontamento.DesRegistro,
                        Inicio = apontamento.DatInicio,
                        Fim = apontamento.DatFim
                    }
                );
            }
            return apontamentos;
        }

        public ICadastro Buscar(uint Id)
        {
            var cadastro = db.Apontamentos.Where( x=> x.IdApontamento == Id).FirstOrDefault();
            if (cadastro != null)
            {
                return new ApontamentosCadastro
                {
                    Id = cadastro.IdApontamento,
                    IdConsultor = cadastro.IdConsultor,
                    IdAtividade = cadastro.IdAtividade,
                    Descricao = cadastro.DesRegistro, 
                    Inicio = cadastro.DatInicio,
                    Fim = cadastro.DatFim
                };
            }
            else return null;

        }
        public void Cadastrar(ICadastro c)
        {
            var apontamento = (ApontamentosCadastro) c;
            db.Apontamentos.Add(
                new Apontamentos 
                {
                    IdAtividade = Convert.ToUInt32(apontamento.IdAtividade),
                    IdConsultor = apontamento.IdConsultor,
                    DesRegistro = apontamento.Descricao,
                    DatInicio = apontamento.Inicio,
                    DatFim = apontamento.Fim,
                    DatRegistro = DateTime.Now
                }
            );
        }

        public void Alterar(ICadastro c)
        {
            var apontamento = (ApontamentosCadastro) c;
            var cadastro = db.Apontamentos.Where(x => x.IdApontamento == apontamento.Id).FirstOrDefault();
            if (cadastro != null)
            {
                cadastro.IdAtividade = apontamento.IdAtividade;
                cadastro.IdConsultor = apontamento.IdConsultor;
                cadastro.DesRegistro = apontamento.Descricao;
                cadastro.DatInicio = apontamento.Inicio;
                cadastro.DatFim = apontamento.Fim;
                cadastro.DatRegistro = DateTime.Now;
                db.Apontamentos.Update(cadastro);
                db.SaveChanges();
            }
            else
            {
                Cadastrar(c);
            }
        }
        public bool Deletar (uint id)
        {
            var cadastro = db.Apontamentos.Where(x => x.IdApontamento == id).FirstOrDefault();
            if (cadastro != null)
            {
                db.Apontamentos.Remove(cadastro);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}