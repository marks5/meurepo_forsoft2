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
            //Mudar a action para o php e o método de envio de dados
            return Content("<form action='http://www2.stevent.com.br/valida.php' id='frmTest' method='post'><input type='hidden' name='usuario' value='" + usuario + "' /><input type='hidden' name='senha' value='" + senha + "' /></form><script>document.getElementById('frmTest').submit();</script>");
        }

        [HttpPost]
        public ActionResult recebeDoPHP(string idUsuario)
        {
            
            if (idUsuario != null)
            {
                ViewBag.Erro = "Usuário ou senha inválidos";
                return View("Index");
            } else
            {
                //Falta persistir aqui
                //Antes desse código tem que ver as permissões no banco
                HttpCookie passou = new HttpCookie("biscoito");
                passou.Domain = "stevent.com.br";
                passou.Values.Add("idUsuario", idUsuario);
                //passou.Values.Add("senha", );
                return Redirect("http://www2.stevent.com.br:8080/listarEventos");
            }
            
        }

        [HttpPost]
        public ActionResult enviaJava(string usuario,string senha)
        {
            HttpCookie passa = new HttpCookie("net");
            passa.Domain = "stevent.com";
            passa.Values.Add("usuarioChave", usuario);
            return Redirect("http://192.168.1.2:8080/Stevent");
        }

    }
}