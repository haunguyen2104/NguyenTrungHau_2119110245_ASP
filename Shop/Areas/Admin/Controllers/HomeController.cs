using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            //if (Session["UserAdmin"] == null)
            //{
            //    return RedirectToAction("LoginAdmin", "Home");
            //}
            var listProduct = objWebsiteBanHangEntities.Product_2119110245.Where(a => a.Deleted == false).ToList();
            var listCategory = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.Deleted == false).ToList();
            var listBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(a => a.Deleted == false).ToList();
            var listUser = objWebsiteBanHangEntities.User_2119110245.Where(a => a.IsActive != 0).ToList();
            var listOrder = objWebsiteBanHangEntities.Order_2119110245.ToList();
            var listOrderDetail = objWebsiteBanHangEntities.OrderDetail_2119110245.ToList();
            //Delivery = 3 là giao hàng thành công => Khách hàng đã nhận được hàng
            var objOrderSuccess = listOrder.Where(a => a.Delivery == 3).ToList().Count;
            float DeliverySuccess = objOrderSuccess * 100 / listOrder.Count;
    

            DashboardModel objModel = new DashboardModel();
            objModel.listProduct = listProduct;
            objModel.listUser = listUser;
            objModel.listOrder = listOrder;
            objModel.DeliverySuccessful = DeliverySuccess;
            objModel.OrderSuccess = int.Parse(objOrderSuccess.ToString());
            return View(objModel);
        }
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = ConvertMD5.GetMD5(password);
                var data = objWebsiteBanHangEntities.User_2119110245.Where(s => s.IsAdmin == 1 && s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session

                    Session["FullNameAdmin"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    var name = Session["FullNameAdmin"].ToString();
                    Session["EmailAdmin"] = data.FirstOrDefault().Email;
                    Session["UserAdmin"] = data.FirstOrDefault().Id;

                    //Session["IsAdmin"] = data.FirstOrDefault().IsAdmin;
                    //TempData["success"] = "Đăng nhập thành công";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Sai thông tin tài khoản hoặc mật khẩu";
                    //ViewBag.error = "Login failed";
                    return RedirectToAction("LoginAdmin");
                }
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//Remove session
            //return RedirectToAction("Index");
            //return Redirect("/trang-chu");
            return Redirect("/quan-tri/dang-nhap-he-thong");


        }
    }

}