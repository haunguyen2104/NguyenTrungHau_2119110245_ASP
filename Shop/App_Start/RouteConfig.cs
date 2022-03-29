using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Tuỳ biến Url khác
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
            routes.MapRoute(
                name: "AllCategory",
                url: "tat-ca-danh-muc",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "productDetail",
              url: "chi-tiet/{Slug}",
              defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }
          );*/
            //Tuỳ biến Url 1 cấp
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                  new[] { "Shop.Controllers" }
            );
        }
    }
}
