using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Base
        public BaseController()
        {
            /*
            //Kiểm tra chưa đăng nhập
            if (System.Web.HttpContext.Current.Session["UserAdmin"] == null)
            {
                //Chuyển hướng website
                System.Web.HttpContext.Current.Response.Redirect("/Admin/Home/LoginAdmin");
            }
            */
            var listProduct = objWebsiteBanHangEntities.Product_2119110245.Where(a => a.Deleted == false).ToList();
            var listCategory = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.Deleted == false).ToList();
            var listBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(a => a.Deleted == false).ToList();
            var listUser = objWebsiteBanHangEntities.User_2119110245.Where(a => a.IsActive != 0).ToList();
            var listOrder = objWebsiteBanHangEntities.Order_2119110245.ToList();
            //Delivery = 3 là giao hàng thành công => Khách hàng đã nhận được hàng
            var objOrderSuccess = listOrder.Where(a => a.Delivery == 3).ToList().Count;
            float DeliverySuccess = objOrderSuccess * 100 / listOrder.Count;
            ViewBag.TongSoSanPhamOLayout = listProduct.Count;
            ViewBag.TongSoDanhMucOLayout = listCategory.Count;
            ViewBag.TongSoThuongHieuOLayout = listBrand.Count;
            ViewBag.TongSoDonHangOLayout = listOrder.Count;
            ViewBag.TongSoThanhVienOLayout = listUser.Count;
           
        }
    }
}
