using System.Web.Mvc;

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

            //Quản trị sản phẩm-----------------------------------------------------------------
            ///Danh sách sản phẩm
            context.MapRoute(
                "ProductList",
                "quan-tri/danh-sach-san-pham",
                new { controller="Product",action = "Index", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            ///cập nhật sản phẩm
            context.MapRoute(
                "UpdateProduct",
                "quan-tri/san-pham/cap-nhap/{Slug}-{Id}",
                new { controller="Product",action = "Edit", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            ///Xem sản phẩm
            context.MapRoute(
                "DetailProduct",
                "quan-tri/san-pham/chi-tiet/{Slug}-{Id}",
                new { controller="Product",action = "Details", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            ///Xoá sản phẩm vào thùng rác
            context.MapRoute(
                "ToggleTrashProduct",
                "quan-tri/san-pham/khoi-phuc/{Slug}-{Id}",
                new { controller="Product",action = "ToggleTrash", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            ///Khôi phục sản phẩm
            context.MapRoute(
            "RecoverProduct",
            "quan-tri/san-pham/xoa/{Slug}-{Id}",
            new { controller = "Product", action = "Recover", id = UrlParameter.Optional },
              new[] { "Shop.Areas.Admin.Controllers" }
        );
            ///Xoá vính viễn sản phẩm
            context.MapRoute(
            "DeleteProduct",
            "quan-tri/san-pham/xoa/{Slug}-{Id}",
            new { controller = "Product", action = "Delete", id = UrlParameter.Optional },
              new[] { "Shop.Areas.Admin.Controllers" }
        );
            //Thêm sản phẩm
            context.MapRoute(
                "NewProduct",
                "quan-tri/san-pham/them-moi",
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

            //Quản trị danh mục-----------------------------------------------------------------
            ///Danh sách danh mục
            context.MapRoute(
                "CategoryList",
                "quan-tri/danh-sach-danh-muc",
                new { controller="Category",action = "Index", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            ///cập nhật danh mục
            context.MapRoute(
                "CategoryEdit",
                "danh-muc/cap-nhat/{Slug}-{BrandId}",
                new { controller="Category",action = "Edit", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            ///Thêm danh mục
            context.MapRoute(
                "NewCategory",
                "quan-tri/them-moi-danh-muc",
                new { controller = "Category", action = "Create", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            ///Thùng rác
            context.MapRoute(
                "CategoryListInTrash",
                "quan-tri/danh-muc/thung-rac",
                new { controller = "Category", action = "ListInTrash", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );

            //Quản trị thương hiệu-----------------------------------------------------------------
            ///Danh sách thương hiệu
            context.MapRoute(
                "BrandList",
                "quan-tri/danh-sach-thuong-hieu",
                new { controller="Brand",action = "Index", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );

            ///cập nhật thương hiệu
            context.MapRoute(
                "BrandEdit",
                "thuong-hieu/cap-nhat/{Slug}-{BrandId}",
                new { controller = "Brand", action = "Edit", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            ///Thêm danh mục
            context.MapRoute(
                "NewBrand",
                "quan-tri/them-moi-thuong-hieu",
                new { controller = "Brand", action = "Create", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );
            ///Thùng rác
            context.MapRoute(
                "BrandListInTrash",
                "quan-tri/thuong-hieu/thung-rac",
                new { controller = "Brand", action = "ListInTrash", id = UrlParameter.Optional },
                  new[] { "Shop.Areas.Admin.Controllers" }
            );

            //Quản trị slider-----------------------------------------------------------------
            ///Danh sách hình ảnh slider
            context.MapRoute(
                "SliderList",
                "quan-tri/danh-sach-hinh-anh",
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