using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ContactMasterData
    {
        public int ContactId { get; set; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage ="Vui lòng nhập họ tên!")]
        public string FullName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        public string Email { get; set; }
        //[Required(ErrorMessage = "Vui lòng nhập email!")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        //[Required(ErrorMessage ="Vui lòng nhập nội dung liên hệ!")]
        [Display(Name = "Nội dung liên hệ")]
        public string Detail { get; set; }
        [Display(Name = "Ngày gửi")]
        public Nullable<System.DateTime> CreateAt { get; set; }
        [Display(Name = "Trạng thái")]
        public Nullable<int> Status { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}