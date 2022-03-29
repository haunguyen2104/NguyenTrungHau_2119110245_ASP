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
        [Required]
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        public Nullable<int> IsAdmin { get; set; }
    }
}