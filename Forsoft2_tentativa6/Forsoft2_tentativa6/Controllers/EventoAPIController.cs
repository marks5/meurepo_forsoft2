using Forsoft2.Dominio;
using System.Collections.Generic;
using System.Web.Http;
using Forsoft2.Aplicacao;

namespace Forsoft2_tentativa6.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/EventoAPI
        public List<Evento> Get()
        {
            return new EventoAplicacao().ListarAPI();
        }

        // GET: api/EventoAPI/5
        public Evento Get(int id)
        {
            return new EventoAplicacao().ListarPorID(id);
        }

        // DELETE: api/EventoAPI/5
        public void Delete(int id)
        {
            new EventoAplicacao().Excluir(id);
        }
    }
}
