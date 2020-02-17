using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyncaBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default7",
                url: "Registration",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional });
            routes.MapRoute(
                name: "Default6",
                url: "Login",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional });
            routes.MapRoute(
                name: "Default5",
                url: "EditPost",
                defaults: new { controller = "User", action = "EditPost", id = UrlParameter.Optional});

            routes.MapRoute(
                name: "Default4",
                url: "NewPost",
                defaults: new { controller = "User", action = "CreatePost" });

            routes.MapRoute(
                name: "Default3",
                url: "LatestPosts_{page}",
                defaults: new { controller = "Home", action = "Index", page = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default2",
                url: "ReadPost_{id}_{page}",
                defaults: new { controller = "Home", action = "PostDetails", id = UrlParameter.Optional, page = 1 });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
