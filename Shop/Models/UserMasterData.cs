using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class UserMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Họ")]

        public string FirstName { get; set; }
        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [Required(ErrorMessage="Bạn chưa nhập email")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage="Bạn chưa nhập mật khẩu")]
        public string Password { get; set; }
        public Nullable<int> IsAdmin { get; set; }
    }
}