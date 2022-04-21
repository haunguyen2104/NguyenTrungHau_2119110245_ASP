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
            ///URL FREINDLY KHÔNG DÙNG BIẾN
            //Trang chủ
            routes.MapRoute(name: "HomePageUser", url: "trang-chu", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Tất cả danh mục
            routes.MapRoute(name: "AllCategory", url: "tat-ca-danh-muc", defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Tất cả thương hiệu
            routes.MapRoute(name: "AllBrand", url: "tat-ca-thuong-hieu", defaults: new { controller = "Brand", action = "Index", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Thanh toán
            routes.MapRoute(name: "Payment", url: "thanh-toan-thanh-cong", defaults: new { controller = "Payment", action = "Index", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Giỏ hàng
            routes.MapRoute(name: "Cart", url: "gio-hang", defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Đăng nhập
            routes.MapRoute(name: "Login", url: "dang-nhap", defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Đăng nhập
            routes.MapRoute(name: "Logout", url: "dang-xuat", defaults: new { controller = "Home", action = "Logout", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Đăng ký
            routes.MapRoute(name: "Register", url: "dang-ky", defaults: new { controller = "Home", action = "Register", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Về chúng tôi
            routes.MapRoute(name: "About", url: "ve-chung-toi", defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //San pham uu dai
            routes.MapRoute(name: "DealAndOffers", url: "san-pham-uu-dai-cuc-soc", defaults: new { controller = "Product", action = "Offers", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Liên hệ
            routes.MapRoute(name: "Contact", url: "lien-he", defaults: new { controller = "Contacts", action = "SendContact", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            //Tìm kiếm
            routes.MapRoute(name: "Search", url: "tim-kiem", defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            ///URL FREINDLY DÙNG BIẾN
            ////Sản phẩm theo danh mục (List)
            routes.MapRoute(name: "ProductCategoryList", url: "san-pham/danh-muc/danh-sach/{Slug}-{id}", defaults: new { controller = "Product", action = "ProductCategoryList", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            ////Sản phẩm theo danh mục (Grid)
            routes.MapRoute(name: "ProductCategoryGrid", url: "san-pham/danh-muc/luoi/{Slug}-{id}", defaults: new { controller = "Product", action = "ProductCategoryGrid", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });
            ////Sản phẩm theo thương hiệu (List)
            routes.MapRoute(name: "ProductBrandList",url: "san-pham/thuong-hieu/danh-sach/{Slug}-{id}",defaults: new { controller = "Product", action = "ProductBrandList", id = UrlParameter.Optional },new[] { "Shop.Controllers" });
            ////Sản phẩm theo thương hiệu (Grid)
            routes.MapRoute(name: "ProductBrandGrid", url: "san-pham/thuong-hieu/luoi/{Slug}-{id}",defaults: new { controller = "Product", action = "ProductBrandGrid", id = UrlParameter.Optional },new[] { "Shop.Controllers" });
            //Chi tiết sản phẩm
            routes.MapRoute(name: "ProductDetail", url: "chi-tiet/{Slug}-{Id}", defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }, new[] { "Shop.Controllers" });

            //Url Default
            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    new[] { "Shop.Controllers" }
                );
        }
    }
}
