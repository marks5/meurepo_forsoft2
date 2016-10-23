﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forsoft2_tentativa6.Controllers
{
    public class ListaController : Controller
    {
        // GET: Lista
        public ActionResult Recursos()
        {
            return RedirectToAction("Index","Recurso");
        }

        public ActionResult Usuarios()
        {
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult Atletas()
        {
            return Redirect("http://www.stevent.com:8080/listarAtletas");
        }

        public ActionResult Equipes()
        {
            return Redirect("http://www.stevent.com:8080/listarEquipes");
        }
        public ActionResult Eventos()
        {
            return Redirect("http://www.stevent.com:8080/listarEventos");
        }
        public ActionResult Locais()
        {
            return Redirect("http://www.stevent.com:8080/listarLocais");
        }
    }
}