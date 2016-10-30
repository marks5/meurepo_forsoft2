using Forsoft2.Aplicacao;
using Forsoft2.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forsoft2_tentativa6.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var appUsuario = new UsuarioAplicacao().ListarTodos();
            return View(appUsuario);
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario, FormCollection collection)
        {
            usuario.Equipe = new Equipe()
            {
                idEquipe = Convert.ToInt32(Request.Form["equipe"])
            };

            var CatchUsuario = new UsuarioAplicacao();
            CatchUsuario.Salvar(usuario);
            return RedirectToAction("Index");
        }

        public JsonResult GetUsuario(int id)
        {
            var resultado = new UsuarioAplicacao().ListarPorID(id);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var CatchUsuario = new UsuarioAplicacao();
            CatchUsuario.Excluir(id);
            return RedirectToAction("Index");
        }
    }

}