using Forsoft2.Aplicacao;
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
    }
}