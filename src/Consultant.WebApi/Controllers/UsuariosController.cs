using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Business;

namespace ConsulTeam.WebApi.Controllers
{
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        private UsuariosBusiness usuariosBusiness = new UsuariosBusiness();
        // GET api/values
        [HttpGet]
        [Route("Get")]
        public List<ICadastro> Get()
        {
            return usuariosBusiness.Buscar();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public ICadastro Get(uint id)
        {
            return usuariosBusiness.Buscar(id);
        }


        [HttpPost]
        [Route("Login")]
        public bool Login([FromBody]Login login)
        {
            try
            {
                return usuariosBusiness.Login(login);
            }
            catch (System.Exception)
            {
                
                return false;
            }

        }

        // POST api/values
        [HttpPost]
        [Route("Post")]
        public String Post([FromBody]UsuarioCadastro usuarioCadastro)
        {
            try
            {
                usuariosBusiness.Cadastrar(usuarioCadastro);
                return "Cadastro realizado com sucesso";   
            }
            catch (System.Exception ex)
            {
                return ex.Message;                
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
        
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(uint id)
        {
            usuariosBusiness.Deletar(id);
        }
    }
}
