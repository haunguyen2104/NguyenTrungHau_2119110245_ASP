using Shop.Context;
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
            var objUser = objWebsiteBanHangEntities.User_2119110245.Where(x => x.Id == id).FirstOrDefault();
            return View(objUser);
        }
     
    }
}