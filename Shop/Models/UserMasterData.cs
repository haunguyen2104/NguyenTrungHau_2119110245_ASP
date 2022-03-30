using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Context
{
    public class UserMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Không được để trống.")]
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Không được để trống.")]
        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Không được để trống.")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Không được để trống.")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        public Nullable<int> IsAdmin { get; set; }
    }
}