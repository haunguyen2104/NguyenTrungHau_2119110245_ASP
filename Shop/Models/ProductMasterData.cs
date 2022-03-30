using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Context
{
    public partial class ProductMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập tên sản phẩm!")]
        [Display(Name="Tên sản phẩm")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm!")]
        [Display(Name = "Tên sản phẩm đẩy đủ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh!")]
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Required]
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> CategoryId { get; set; }
        [Required]
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShoetDes { get; set; }
        [Display(Name = "Mô tả đầy đủ")]
        public string FullDescription { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm!")]
        [Display(Name = "Giá")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> TypeId { get; set; }
        [Display(Name = "Slug")]
        public string Slug { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng sản phẩm!")]
        [Display(Name = "Số lượng")]
        public Nullable<int> Quantity { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}