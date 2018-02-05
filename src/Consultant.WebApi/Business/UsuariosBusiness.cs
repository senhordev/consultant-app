using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;

namespace API.Business
{
    // Classe que representa o cadastro dos usuarios
    public partial class UsuarioCadastro : ICadastro
    {
        public UInt32 Id { get; set; }
        public uint IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    // Classe que representa o Login do usuario
    public partial class Login 
    {
        public string email;
        public string senha;
    }

    // Classe de execução das regras de negócio dos usuarios
    public class UsuariosBusiness : IBusiness
    {
       public bool Login(Login login)
        {
            try
            {
                MyDbContext contexto = new MyDbContext();
                double id = (from Usuarios x in contexto.Usuarios.ToList()
                                    where x.DesEmail == login.email && x.DesSenha == login.senha
                                    select x.IdUsuario).FirstOrDefault();
                return id > 0  ? true : false;                
            }
            catch (System.Exception)
            {
                return false;
            }

        }

        public List<ICadastro> Buscar()
        {
            MyDbContext contexto = new MyDbContext();
            List<ICadastro> usuarios = new List<ICadastro>();

            foreach (var u in contexto.Usuarios.ToList())
            {
                usuarios.Add(
                    new UsuarioCadastro 
                    {
                        Id = u.IdUsuario,
                        Nome = u.DesUsuario,
                        Email = u.DesEmail,
                        Senha = u.DesSenha
                    }
                );                
            }

            return usuarios;
        }

        public ICadastro Buscar(uint id)
        {
            MyDbContext contexto = new MyDbContext();
            Usuarios u = contexto.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefault();
            if (u != null)
            {   
                var usuario = new UsuarioCadastro
                {
                    Id = u.IdUsuario,
                    Nome = u.DesUsuario,
                    Email = u.DesEmail,
                    Senha = u.DesSenha
                };
                return usuario;

            }
            else return null;
        }
        public bool Deletar(uint id)
        {
            MyDbContext contexto = new MyDbContext();
            Usuarios usuario = contexto.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefault();
            if (usuario != null)
            {
                contexto.Usuarios.Remove(usuario);
                contexto.SaveChanges();
                return true;
            }
            else return true;
        }

        public void Alterar(ICadastro c)
        {
            var usuario = (UsuarioCadastro) c;
            MyDbContext contexto = new MyDbContext();
            var cadastro = contexto.Usuarios.Where(x => x.IdUsuario == usuario.Id).FirstOrDefault();

            if (cadastro != null)
            {
                cadastro.DesEmail = usuario.Email;
                cadastro.DesSenha = usuario.Senha;
                cadastro.DesUsuario = usuario.Nome;
                cadastro.DatAlteracao = DateTime.Now;
                cadastro.IdUsuario = usuario.IdUsuario;
                contexto.Usuarios.Update(cadastro);
                contexto.SaveChanges();
            }
            else
            {
                Cadastrar(c);
            }
        }
        public void Cadastrar(ICadastro c)
        {
            var usuario = (UsuarioCadastro) c;
            try
            {
                ValidarUsuarioCadastro(usuario);
                Usuarios cadastro = new Usuarios();
                cadastro.DesUsuario = usuario.Nome;
                cadastro.DatRegistro = DateTime.Now;
                cadastro.DatAlteracao = DateTime.Now;
                cadastro.DesSenha = usuario.Senha;
                cadastro.DesEmail = usuario.Email;
                cadastro.IdUsuario = usuario.IdUsuario;

                MyDbContext contexto = new MyDbContext();
                contexto.Add(cadastro);
                contexto.SaveChanges();

            }
            catch (System.Exception ex)
            {
             throw ex;
            }
        }

        public void ValidarUsuarioCadastro(UsuarioCadastro usuarioCadastro)
        {
            if (String.IsNullOrEmpty(usuarioCadastro.Nome)) throw new Exception("Nome de usuário errado");         
            if (String.IsNullOrEmpty(usuarioCadastro.Email)) throw new Exception("Email do usuario não informado");
            if (String.IsNullOrEmpty(usuarioCadastro.Senha)) throw new Exception("Senha do usuario não informada");
        }
 

    }
}
    
