using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class AtividadeCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuario { get; set; }
        public uint? IdProjeto { get; set; }
        public string Titulo { get; set; }
        public string Atividade { get; set; }
    }

    public class AtividadesBusiness : IBusiness
    {
        MyDbContext db;
        
        public AtividadesBusiness () => db = new MyDbContext();
        public AtividadesBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var atividades = new List<ICadastro>();
            foreach (var a in db.Atividades.ToList())
            {
               atividades.Add(
                   new AtividadeCadastro
                   {
                       Id = a.IdAtividade,
                       IdProjeto = a.IdProjeto,
                       IdUsuario = Convert.ToUInt32(a.IdUsuario),
                       Titulo = a.DesTitulo,
                       Atividade = a.DesAtividade,
                   }
               );
            }
            return atividades;
        }
        public ICadastro Buscar(uint Id)
        {
            var cadastro = db.Atividades.Where(x => x.IdAtividade == Id).FirstOrDefault();
            if (cadastro != null)
            {
                return new AtividadeCadastro 
                {
                    Id = cadastro.IdAtividade,
                    IdProjeto = cadastro.IdProjeto,
                    IdUsuario = (uint) cadastro.IdUsuario,
                    Titulo = cadastro.DesTitulo,
                    Atividade = cadastro.DesAtividade
                };
            }
            else return null;
        }
        public void Cadastrar(ICadastro c)
        {
            var a = (AtividadeCadastro)c;
            db.Atividades.Add(
                new Atividades
                {
                    IdProjeto = (uint) a.IdProjeto,
                    IdUsuario = a.IdUsuario,
                    DesTitulo = a.Titulo,
                    DesAtividade = a.Atividade,
                    DatRegistro = DateTime.Now,
                    DatAlteracao = DateTime.Now
                }
            );
        }
        public void Alterar(ICadastro c)
        {
            var a = (AtividadeCadastro)c;
            var cadastro = db.Atividades.Where(x=> x.IdAtividade == c.Id).FirstOrDefault();
            if (cadastro != null)
            {
                cadastro.IdProjeto = (uint) a.IdProjeto;
                cadastro.IdUsuario = a.IdUsuario;
                cadastro.DesAtividade = a.Atividade;
                cadastro.DesAtividade = a.Titulo;
                cadastro.DatAlteracao = DateTime.Now;
                db.Atividades.Update(cadastro);
                db.SaveChanges();
            }
            else Cadastrar(c);
        }
        public bool Deletar (uint id)
        {
            var cadastro = db.Atividades.Where(x=> x.IdAtividade == id).FirstOrDefault();
            if (cadastro != null)
            {
                db.Atividades.Remove(cadastro);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}