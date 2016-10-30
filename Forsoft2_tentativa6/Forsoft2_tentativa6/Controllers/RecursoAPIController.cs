using Forsoft2.Aplicacao;
using Forsoft2.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Forsoft2_tentativa6.Controllers
{
    public class RecursosController : ApiController
    {
        // GET: api/EventoAPI
        public List<Recurso> Get()
        {
            return new RecursoAplicacao().ListarTodos();
        }

        // GET: api/EventoAPI/5
        public Recurso Get(int id)
        {
            return new RecursoAplicacao().ListarPorID(id);
        }

        public List<Recurso> Get(string idEvento)
        {
            return new RecursoAplicacao().ListarPorIDEV(idEvento);
        }

        // POST: api/EventoAPI
        public void Post([FromBody]Recurso recurso)
        {
            new RecursoAplicacao().Salvar(recurso);
        }

        public void Post([FromBody]int idEvento, Recurso recurso)
        {
            new RecursoAplicacao().Inserir(idEvento, recurso);
        }

        // PUT: api/EventoAPI/5
        public void Put(int id, [FromBody]Recurso recurso)
        {
            new RecursoAplicacao().Salvar(recurso);
        }

        // DELETE: api/EventoAPI/5
        public void Delete(int id)
        {
            new RecursoAplicacao().Excluir(id);
        }

        public void Delete(int idEvento, int id)
        {
            new RecursoAplicacao().Excluir(idEvento, id);
        }
    }
}
