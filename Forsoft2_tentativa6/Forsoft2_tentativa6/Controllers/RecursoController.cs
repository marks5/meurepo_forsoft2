using Forsoft2.Aplicacao;
using Forsoft2.Dominio;
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

        [HttpPost]
        public ActionResult Index(Recurso recurso)
        {
            var CatchRecurso = new RecursoAplicacao();
            CatchRecurso.Salvar(recurso);
            return RedirectToAction("Index");
        }

        public JsonResult GetRecurso(int id)
        {
            var resultado = new RecursoAplicacao().ListarPorID(id);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var CatchRecurso = new RecursoAplicacao();
            CatchRecurso.Excluir(id);
            return RedirectToAction("Index");        }
    }
}