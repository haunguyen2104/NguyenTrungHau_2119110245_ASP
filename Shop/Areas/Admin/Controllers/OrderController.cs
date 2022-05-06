using PagedList;
using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Order
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            AdminOrderModel objModel = new AdminOrderModel();
            objModel.ListUser = objWebsiteBanHangEntities.User_2119110245.ToList();
            var pageLstOrder = objWebsiteBanHangEntities.Order_2119110245.ToList();
            //------------------
          
            //------------------

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                objModel.ListOrder = pageLstOrder.Where(n => n.Name.Contains(SearchString)).ToList();
                objModel.ILstOder = (IPagedList<Order_2119110245>)pageLstOrder.Where(n => n.Name.Contains(SearchString)).OrderByDescending(n => n.Id).ToPagedList(pageNumber, pageSize);
            }
            else
            {
                objModel.ILstOder = (IPagedList<Order_2119110245>)pageLstOrder.OrderByDescending(n => n.Id).ToPagedList(pageNumber, pageSize);
                objModel.ListOrder = pageLstOrder.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            return View(objModel);
        }
        public ActionResult DeliveryToggle_Confirm(int id)
        {
            var obj = objWebsiteBanHangEntities.Order_2119110245.Where(n => n.Id == id).FirstOrDefault();
            obj.Delivery = (obj.Delivery == 0) ? 1 : 0;
            //obj.UpdatedOnUtc = DateTime.Now;
            objWebsiteBanHangEntities.Entry(obj).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        } public ActionResult DeliveryToggle(int id)
        {
            var obj = objWebsiteBanHangEntities.Order_2119110245.Where(n => n.Id == id).FirstOrDefault();
            obj.Delivery = (obj.Delivery > 2) ? 1 : 2;
            //obj.UpdatedOnUtc = DateTime.Now;
            objWebsiteBanHangEntities.Entry(obj).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }public ActionResult DeliveryToggle_Recieve(int id)
        {
            var obj = objWebsiteBanHangEntities.Order_2119110245.Where(n => n.Id == id).FirstOrDefault();
            obj.Delivery = (obj.Delivery != 3) ? 3 : 2;
            //obj.UpdatedOnUtc = DateTime.Now;
            objWebsiteBanHangEntities.Entry(obj).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
          
                AdminOrderModel objOrderModel = new AdminOrderModel();
                objOrderModel.ListUser = objWebsiteBanHangEntities.User_2119110245.ToList();
                objOrderModel.ListProduct = objWebsiteBanHangEntities.Product_2119110245.ToList();
                objOrderModel.ListOrder = objWebsiteBanHangEntities.Order_2119110245.Where(n => n.Id == id).ToList();
                objOrderModel.ListOrderDetail = objWebsiteBanHangEntities.OrderDetail_2119110245.Where(n => n.OrderId == id).ToList();
                return View(objOrderModel);
            
        }
    }
}