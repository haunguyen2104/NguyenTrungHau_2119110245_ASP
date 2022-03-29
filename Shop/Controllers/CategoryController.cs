using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Category
        public ActionResult Index()
        {
            var objCateList = objWebsiteBanHangEntities.Category_2119110245.ToList();
            var objProList = objWebsiteBanHangEntities.Product_2119110245.ToList();
            
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.listCategory = objCateList;
            objHomeModel.listProduct = objProList;
            return View(objHomeModel);
        }
    }
}