﻿using System.Web.Mvc;

namespace Shop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //Quản trị
            context.MapRoute(
               "HomePage",
               "quan-tri",
               new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 new[] { "Shop.Areas.Admin.Controllers" }
           );

            //Quản trị sản phẩm
            //Danh sách sản phẩm
            context.MapRoute(
                "ProductList",
                "quan-tri/danh-sach-san-pham",
                new { controller="Product",action = "Index", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            //Thêm sản phẩm
            context.MapRoute(
                "NewProduct",
                "quan-tri/them-moi-san-pham",
                new { controller="Product",action = "Create", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            //Thùng rác
            context.MapRoute(
                "ProductListInTrash",
                "quan-tri/san-pham/thung-rac",
                new { controller="Product",action = "ListInTrash", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );

            //Quản trị danh mục
            //Danh sách danh mục
            context.MapRoute(
                "CategoryList",
                "quan-tri/danh-sach-danh-muc",
                new { controller="Category",action = "Index", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            //Thêm danh mục
            context.MapRoute(
                "NewCategory",
                "quan-tri/them-moi-danh-muc",
                new { controller = "Category", action = "Create", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            //Thùng rác
            context.MapRoute(
                "CategoryListInTrash",
                "quan-tri/danh-muc/thung-rac",
                new { controller = "Category", action = "ListInTrash", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );

            //Quản trị thương hiệu
            //Danh sách thương hiệu
            context.MapRoute(
                "BrandList",
                "quan-tri/danh-sach-thuong-hieu",
                new { controller="Brand",action = "Index", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            //Thêm danh mục
            context.MapRoute(
                "NewBrand",
                "quan-tri/them-moi-thuong-hieu",
                new { controller = "Brand", action = "Create", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            //Thùng rác
            context.MapRoute(
                "BrandListInTrash",
                "quan-tri/thuong-hieu/thung-rac",
                new { controller = "Brand", action = "ListInTrash", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );

            //Quản trị slider
            //Danh sách hình ảnh slider
            context.MapRoute(
                "SliderList",
                "quan-tri/danh-sach-hinh-anh-slider",
                new { controller="Slider",action = "Index", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
        }
    }
}