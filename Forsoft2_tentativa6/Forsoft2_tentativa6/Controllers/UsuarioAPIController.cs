using Forsoft2.Aplicacao;
using Forsoft2.Dominio;
using System.Collections.Generic;
using System.Web.Http;

namespace Forsoft2_tentativa6.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET api/usuarioAPI/
        public List<Usuario> Get()
        {
            return new UsuarioAplicacao().ListarTodos();
        }

        // GET api/usuarioAPI/5
        public Usuario Get(int id)
        {
            return new UsuarioAplicacao().ListarPorID(id);
        }

        // POST api/usuarioAPI
        public void Post([FromBody]Usuario usuario)
        {
            var CatchUsuario = new UsuarioAplicacao();
            CatchUsuario.Salvar(usuario);
        }

        // PUT api/usuarioAPI/5
        public void Put(int id, [FromBody]Usuario usuario)
        {
            var CatchUsuario = new UsuarioAplicacao();
            CatchUsuario.Salvar(usuario);
        }

        // DELETE api/usuarioAPI/5
        public void Delete(int id)
        {
            new RecursoAplicacao().Excluir(id);
        }
    }
}
