﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VaktarSkipan.webui
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}",
                defaults: new { controller = "LogIn", action = "Login"}
            );


            routes.MapRoute(
               name: "MyRoute1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Details", id = 0}
           );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}