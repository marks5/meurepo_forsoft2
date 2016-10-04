using System.Web;
using System.Web.Mvc;
using ASPNET.MVC.Models;

namespace ASPNET.MVC.Controllers
{
    public class AutenticadorController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult enviaAoPHP(string usuario, string senha)
        {
            return Content("<form action='minhaUrlPhp.php' id='frmTest' method='post'><input type='hidden' name='usuario' value='" + usuario + "' /><input type='hidden' name='senha' value='" + senha + "' /></form><script>document.getElementById('frmTest').submit();</script>");
        }

        [HttpPost]
        public ActionResult recebeDoPHP(string usuario, string senha)
        {
            HttpCookie passou = new HttpCookie("biscoito");
            passou.Domain = "stevent.com";
            Md5 md5 = new Md5();
            passou.Values.Add("usuario", "usuario");
            passou.Values.Add("senha", md5.CriptografiaMD5(senha));
            return Redirect("paginaJava.do.Controller");
        }

    }
}