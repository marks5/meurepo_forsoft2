﻿using System.Web;
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
            //Depende de como o AD reconhece vai estar
            usuario.ToLower();
            senha.ToLower();
            //Mudar a action para o php e o método de envio de dados
            return Content("<form action='http://www.google.com.br' id='frmTest' method='get'><input type='hidden' name='usuario' value='" + usuario + "' /><input type='hidden' name='senha' value='" + senha + "' /></form><script>document.getElementById('frmTest').submit();</script>");
        }

        [HttpPost]
        public ActionResult recebeDoPHP(string usuario, string senha)
        {
            
            if (usuario != null)
            {
                ViewBag.Erro = "Usuário ou senha inválidos";
                return View("Index");
            } else
            {
                //Falta persistir aqui
                //Antes desse código tem que ver as permissões no banco
                HttpCookie passou = new HttpCookie("biscoito");
                passou.Domain = "stevent.com";
                Md5 md5 = new Md5();
                passou.Values.Add("usuario", "usuario");
                passou.Values.Add("senha", md5.CriptografiaMD5(senha));
                return Redirect("paginaJava.do.Controller");
            }
            
        }

    }
}