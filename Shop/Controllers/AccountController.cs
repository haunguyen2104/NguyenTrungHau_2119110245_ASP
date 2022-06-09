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
    public class AccountController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Account
        public ActionResult UserProfile(int id)
        {
            AccountModel acc = new AccountModel();
            var objUser = objWebsiteBanHangEntities.User_2119110245.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.Url_Name = ToStringSlug.ToSlug(objUser.FirstName+objUser.LastName);
            var listOrder = objWebsiteBanHangEntities.Order_2119110245.Where(a => a.UserId == id).ToList();
            acc.objUser = objUser;
            acc.ListOrder = listOrder;
            return View(acc);
        }
     
    }
}