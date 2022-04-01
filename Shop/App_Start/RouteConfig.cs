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

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Trang người dùng----------------------------------------
            //Tất cả danh mục
            routes.MapRoute(
               name: "AllCategory",
               url: "tat-ca-danh-muc",
               defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional },
                 new[] { "Shop.Controllers" }
                );
            
            //Tất cả thương hiệu
            routes.MapRoute(
               name: "AllBrand",
               url: "tat-ca-thuong-hieu",
               defaults: new { controller = "Brand", action = "Index", id = UrlParameter.Optional },
                 new[] { "Shop.Controllers" }
                );
            //Sản phẩm theo danh mục dạng danh sách
            //routes.MapRoute(
            //   name: "ProductCategoryList",
            //   url: "san-pham/{id}",
            //   defaults: new { controller = "Product", action = "ProductCategoryList", id = UrlParameter.Optional },
            //     new[] { "Shop.Controllers" }
            //    );


            //Chi tiết sản phẩm
            routes.MapRoute(
               name: "ProductDetail",
               url: "chi-tiet/{Slug}/{Id}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                 new[] { "Shop.Controllers" }
                );
            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                      new[] { "Shop.Controllers" }
                );
        }
    }
}
