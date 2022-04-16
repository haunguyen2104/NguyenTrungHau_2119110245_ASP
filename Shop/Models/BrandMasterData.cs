using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class BrandMasterData
    {
        public int BrandId { get; set; }
        [Display(Name="Tên thương hiệu")]
        public string BrandName { get; set; }
        [Display(Name="Hình ảnh")]
        public string Avatar { get; set; }
        public string Slug { get; set; }
        [Display(Name="H.Thị trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name="Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name="Ngày cập nhật")]
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
        [Display(Name = "Trạng thái xoá")]
        public Nullable<bool> Deleted { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}