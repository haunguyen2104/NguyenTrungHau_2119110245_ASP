using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class BrandController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Brand
        public ActionResult Index()
        {
            var objBrandList = objWebsiteBanHangEntities.Brand_2119110245.ToList();
            return View(objBrandList);
        }
    }
}