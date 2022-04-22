using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var listProduct = objWebsiteBanHangEntities.Product_2119110245.Where(a => a.Deleted == false).ToList();
            DashboardModel objModel = new DashboardModel();
            objModel.listProduct = listProduct;
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
                    var name = Session["FullNameAdmin"];
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
    }
   
}