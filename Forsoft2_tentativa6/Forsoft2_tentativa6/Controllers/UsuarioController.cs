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

        public ActionResult Cadastrar()
        {
            return View();
        }


        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var appUsuario = new UsuarioAplicacao();
                    appUsuario.Salvar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Editar(int id)
        {
            var appUsuario = new UsuarioAplicacao();
            var usuario = appUsuario.ListarPorID(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }


        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var appUsuario = new UsuarioAplicacao();
                appUsuario.Salvar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Excluir(int id)
        {
            var appUsuario = new UsuarioAplicacao();
            var usuario = appUsuario.ListarPorID(id);

            if (usuario == null) return HttpNotFound();

            return View(usuario);
        }


        //[ValidateAntiForgeryToken]
        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var appUsuario = new UsuarioAplicacao();
            appUsuario.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}