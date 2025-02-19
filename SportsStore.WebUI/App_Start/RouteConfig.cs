using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route for pagination with optional category
            routes.MapRoute(
                name: "PagedWithCategory",
                url: "Page{page}/Category/{category}",
                defaults: new
                {
                    controller = "Product",
                    action = "List",
                    category = UrlParameter.Optional
                }
            );

            // Route for pagination without category
            routes.MapRoute(
                name: "Paged",
                url: "Page{page}",
                defaults: new
                {
                    controller = "Product",
                    action = "List"
                }
            );

            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }

}
