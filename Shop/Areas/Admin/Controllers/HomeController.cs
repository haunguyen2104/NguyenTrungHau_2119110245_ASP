﻿using Shop.Context;
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

            return View();
        }
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(string email, string password)
        {
            //if (ModelState.IsValid)
            //{
            //    var f_password = ConvertMD5.GetMD5(password);
            //    var data = objWebsiteBanHangEntities.User_2119110245.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
            //    if (data.Count() > 0)
            //    {
            //        //add session
            //        Session["FullNameAdmin"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
            //        var name = Session["FullNameAdmin"];
            //        Session["Email"] = data.FirstOrDefault().Email;
            //        Session["Id"] = data.FirstOrDefault().Id;
            //        //Session["IsAdmin"] = data.FirstOrDefault().IsAdmin;
            //        //TempData["success"] = "Đăng nhập thành công";
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        TempData["error"] = "Sai thông tin tài khoản hoặc mật khẩu";
            //        //ViewBag.error = "Login failed";
            //        return RedirectToAction("LoginAdmin");
            //    }
            //}

            return View();
        }
    }
}