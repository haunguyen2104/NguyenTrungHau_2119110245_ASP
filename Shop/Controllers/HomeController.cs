using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
namespace Shop.Controllers
{
    
    public class HomeController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        public ActionResult Index()
        {
            //Lấy sản phẩm giá sốc
           // var listProduct= objWebsiteBanHangEntities.C2119110245_Product.ToList();
            var listProducts = objWebsiteBanHangEntities.Product_2119110245.ToList();
            //Lấy danh mục sản phẩm
            var listCategory = objWebsiteBanHangEntities.Category_2119110245.ToList();
            //Lấy thương hiệu
            var listBrand = objWebsiteBanHangEntities.Brand_2119110245.ToList();
            //Lấy slider
            var listSlider = objWebsiteBanHangEntities.Slider_2119110245.ToList();
            HomeModel objhomeModel = new HomeModel();
            objhomeModel.listCategory = listCategory;
            objhomeModel.listProduct = listProducts;
            objhomeModel.listBrand = listBrand;
            objhomeModel.listSilder = listSlider;
            return View(objhomeModel);
        }

        public ActionResult Register()
        {
            return View();
        }
        //POST: Register
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Register(User_2119110245 _user)
        {
            if (ModelState.IsValid)
            {
                var check = objWebsiteBanHangEntities.User_2119110245.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    //_user.Password = GetMD5(_user.Password);
                    _user.Password = ConvertMD5.GetMD5(_user.Password);
                    objWebsiteBanHangEntities.Configuration.ValidateOnSaveEnabled = false;
                    objWebsiteBanHangEntities.User_2119110245.Add(_user);
                    objWebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = ConvertMD5.GetMD5(password);
                var data = objWebsiteBanHangEntities.User_2119110245.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Id"] = data.FirstOrDefault().Id;
                    Session["IsAdmin"] = data.FirstOrDefault().IsAdmin;
                    return RedirectToAction("Index");
                }
                else
                {
            TempData["error"] = "Sai thông tin tài khoản hoặc mật khẩu";
                    //ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//Remove session
            return RedirectToAction("Login");
        }

    }
}