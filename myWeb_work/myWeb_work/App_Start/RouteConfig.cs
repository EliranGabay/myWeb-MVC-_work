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
                name: "Home",
                url: "",
                defaults: new { controller = "HomePage", action = "ShowHome", id = UrlParameter.Optional }
            );
        }
    }
}
