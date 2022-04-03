using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class PostMasterData
    {
     [Display(Name ="Mã bài viết")]
        public int PostId { get; set; }
     [Display(Name ="Tên bài viết")]
        public string PostTitle { get; set; }
        public string PostSlug { get; set; }
     [Display(Name ="Hình ảnh bài viết")]
        public string PostAvatar { get; set; }
        public string PostDetail { get; set; }
        public Nullable<System.DateTime> PostDateCreate { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public Nullable<int> status { get; set; }
    }
}