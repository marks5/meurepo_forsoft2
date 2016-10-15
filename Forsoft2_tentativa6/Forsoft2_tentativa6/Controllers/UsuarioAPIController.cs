using Forsoft2.Aplicacao;
using Forsoft2.Dominio;
using System.Collections.Generic;
using System.Web.Http;

namespace Forsoft2.API_REST.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET api/values
        public List<Usuario> Get()
        {
            return new UsuarioAplicacao().ListarTodos();
        }

        // GET api/values/5
        public Usuario Get(int id)
        {
            return new UsuarioAplicacao().ListarPorID(id);
        }

        // POST api/values
        public void Post([FromBody]Usuario usuario)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            new UsuarioAplicacao().Excluir(id);
        }
    }
}
