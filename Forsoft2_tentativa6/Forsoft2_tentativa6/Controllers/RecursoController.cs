using Forsoft2.Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forsoft2_tentativa6.Controllers
{
    public class RecursoController : Controller
    {
        // GET: Recurso
        public ActionResult Index()
        {
            var appRecurso = new RecursoAplicacao().ListarTodos();
            return View(appRecurso);
        }
    }
}