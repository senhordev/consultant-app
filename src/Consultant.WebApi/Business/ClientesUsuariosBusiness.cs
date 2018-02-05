using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    public class ClientesUsuariosCadastro : ICadastro
    {
        public uint Id { get; set; }
        public uint IdUsuarioCliente { get; set; }
        public uint IdUsuario { get; set; }
    }

    public class ClientesUsuariosBusiness : IBusiness
    {
        MyDbContext db;
        
        public ClientesUsuariosBusiness () => db = new MyDbContext();
        public ClientesUsuariosBusiness (MyDbContext c) => db = c; 

        public List<ICadastro> Buscar()
        {
            var clientesusuarios = new List<ICadastro>();
            foreach (var c in db.Clientesusuarios.ToList())
            {
                clientesusuarios.Add(
                    new ClientesUsuariosCadastro
                    {
                        Id = c.IdCliente,
                        IdUsuarioCliente = c.IdUsuarioCliente,
                        IdUsuario = Convert.ToUInt32(c.IdUsuarios) 
                    }
                );
            }
            return clientesusuarios;
        }

        public ICadastro Buscar(uint Id)
        {
            var c = db.Clientesusuarios.Where(x => x.IdCliente == Id).FirstOrDefault();
            if (c != null)
            {
                return new ClientesUsuariosCadastro
                {
                    Id = c.IdCliente,
                    IdUsuarioCliente = c.IdUsuarioCliente,
                    IdUsuario = Convert.ToUInt32(c.IdUsuarios)
                };
            }
            else return null;
        }

        public void Cadastrar(ICadastro c)
        {
            var cadastro = (ClientesUsuariosCadastro) c;
            db.Clientesusuarios.Add(
                new Clientesusuarios {
                    IdCliente = cadastro.Id,
                    IdUsuarioCliente = cadastro.IdUsuarioCliente,
                    IdUsuarios = cadastro.IdUsuario,
                    DatRegistro = DateTime.Now
                }
            );
            db.SaveChanges();
        }

        public void Alterar(ICadastro c)
        {
            var cadastro = (ClientesUsuariosCadastro) c;
            var cliente = db.Clientesusuarios.Where( x => x.IdCliente == c.Id).FirstOrDefault();
            if (cliente !=  null)
            {
                cliente.IdUsuarioCliente = cadastro.IdUsuarioCliente;
                cliente.DatRegistro = DateTime.Now;
                db.Clientesusuarios.Update(cliente);
                db.SaveChanges();
            }
            else
            {
                Cadastrar(c);
            }
        }
        public bool Deletar (uint id)
        {
            var c = db.Clientesusuarios.Where(x => x.IdCliente == id).FirstOrDefault();
            if (c != null)
            {
                db.Clientesusuarios.Remove(c);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }

}