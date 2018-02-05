using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    // Classe que representa o cadastro dos clientes
    public partial class ClienteCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuario { get; set; }
        public string DesCliente { get; set; }
        public uint NumCnpj { get; set; }

    }

    // Classe de execução das regras de negócio dos usuarios
    public class ClienteBusiness : IBusiness
    {
        public List<ICadastro> Buscar()
        {
            MyDbContext db = new MyDbContext();            
            List<ICadastro> clientes = new List<ICadastro>();
            foreach (var cliente in db.Clientes.ToList())
            {
                clientes.Add( 
                    new ClienteCadastro 
                    {
                        Id = cliente.IdCliente,
                        DesCliente = cliente.DesCliente,
                        NumCnpj = Convert.ToUInt32(cliente.NumCnpj)
                    }
                );
            }
            return clientes;
        }

        public ICadastro Buscar (uint id)
        {
            MyDbContext db = new MyDbContext();
            var c = db.Clientes.Where(x => x.IdCliente == id).FirstOrDefault();
            if (c != null)
            {
                ClienteCadastro cliente = new ClienteCadastro
                {
                    Id = c.IdCliente,
                    DesCliente = c.DesCliente.ToString(),
                    NumCnpj = Convert.ToUInt32(c.NumCnpj)
                };
                return cliente;
            }
            else return null;
        }

        public void Cadastrar (ICadastro c)
        {
            var item = (ClienteCadastro) c;
            MyDbContext db = new MyDbContext();
            Clientes cliente = new Clientes();
            cliente.DesCliente = item.DesCliente;
            cliente.NumCnpj = Convert.ToUInt32(item.NumCnpj);
            cliente.DatRegistro = DateTime.Now;
            cliente.IdUsuario = item.IdUsuario;
            cliente.DatAlteracao = DateTime.Now;
            db.Clientes.Add(cliente);
            db.SaveChanges();
        }

        public void Alterar (ICadastro c)
        {
            var item = (ClienteCadastro) c;
            MyDbContext db = new MyDbContext();
            Clientes cliente = db.Clientes.Where(x => x.IdCliente == item.Id).FirstOrDefault();

            if (c != null)
            {
                cliente.DesCliente = item.DesCliente;
                cliente.NumCnpj = Convert.ToUInt32(item.NumCnpj);
                cliente.IdUsuario = item.IdUsuario;
                cliente.DatAlteracao = DateTime.Now;
                db.Clientes.Update(cliente);
                db.SaveChanges();
            }
            else
            {
                Cadastrar(item);
            }
        }
        public bool Deletar (uint id)
        {
            MyDbContext db = new MyDbContext();
            var cliente = db.Clientes.Where(x => x.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                db.Clientes.Remove(cliente);
                db.SaveChanges();
                return true;
            }
            else return false;
        }

    }
}
    
