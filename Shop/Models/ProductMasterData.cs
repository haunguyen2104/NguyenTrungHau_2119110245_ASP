using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ProductMasterData
    {
        //Thêm các trường
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm!")]
        [Display(Name = "Tên sản phẩm đầy đủ")]
        public string FullName { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShoetDes { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả!")]
        [Display(Name = "Chi tiết")]
        public string FullDescription { get; set; }
        [Required(ErrorMessage = "Vui lòng giá sản phẩm!")]
        [Display(Name = "Giá sản phẩm")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Loại sản phẩm")]

        public Nullable<int> TypeId { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Xoá")]
        public Nullable<bool> Deleted { get; set; }
        [Display(Name = "Hiển thị trang chủ")]

        public Nullable<bool> ShowOnHomePage { get; set; }
        [Display(Name = "Hiển thị")]

        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
        [Display(Name = "Số lượng")]
        public Nullable<int> Quantity { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}