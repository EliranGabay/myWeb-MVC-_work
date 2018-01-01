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
                url: "",
                defaults: new { controller = "HomePage", action = "HomePage", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "HomePageWithUser",
                url: "",
                defaults: new { controller = "HomePage", action = "HomePageWithUser", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "SignUp",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "User", action = "Sign_Up", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Login",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Logout",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "User", action = "Logout", id = UrlParameter.Optional }
           );
        }
    }
}
