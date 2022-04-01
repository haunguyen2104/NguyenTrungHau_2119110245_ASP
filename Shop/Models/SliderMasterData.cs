using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class SliderMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên hình ảnh!")]
        [Display(Name = "Tên hình ảnh")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh!")]
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        public string Class { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}