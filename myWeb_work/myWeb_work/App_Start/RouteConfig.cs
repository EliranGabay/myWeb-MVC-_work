﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace myWeb_work
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.config");

            routes.MapRoute(
                name: "HomePage",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomePage", action = "HomePage", id = UrlParameter.Optional }
            );
        }
    }
}
