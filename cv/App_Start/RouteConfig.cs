using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cv
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "default", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "Page404",
            url: "{url}",
             new { controller = "Default", action = "Page404" }
        );

        }
    }
}
