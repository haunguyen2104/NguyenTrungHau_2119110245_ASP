using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Order
        public ActionResult Index()
        {
            if (Session["Id"]==null)
            {
                Redirect("/dang-nhap");
            }
            int idUser = int.Parse(Session["Id"].ToString());
            var listOrder = objWebsiteBanHangEntities.Order_2119110245.Where(a => a.UserId == idUser).ToList();

            return View(listOrder);
        }
    }
}