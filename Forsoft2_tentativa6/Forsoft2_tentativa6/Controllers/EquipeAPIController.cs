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
    public class EquipesController : ApiController
    {
        // GET: api/EquipeAPI
        public List<Equipe> Get()
        {
            return new EquipeAplicacao().ListarTodos();
        }
    }
}
