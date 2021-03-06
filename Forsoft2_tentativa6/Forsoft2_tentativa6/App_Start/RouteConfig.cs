﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Forsoft2.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Padrao",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Autenticador", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
