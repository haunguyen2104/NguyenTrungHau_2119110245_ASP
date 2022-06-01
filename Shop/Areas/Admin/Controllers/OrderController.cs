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
        //LOAD DANH SÁCH ĐƠN HÀNG-------------------------------------------------------------------------------------
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            if (Session["UserAdmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Home");
            }
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
        //TOGGLE TRẠNG THÁI ĐƠN HÀNG----------------------------------------------------------------------------------
        ///XÁC NHẬN ĐƠN HÀNG
        //////--Field: Delivery có giá trị 0: Chưa xác nhận, 1: Đã xác nhận
        public ActionResult DeliveryToggle_Confirm(int id)
        {
            var obj = objWebsiteBanHangEntities.Order_2119110245.Where(n => n.Id == id).FirstOrDefault();
            obj.Delivery = (obj.Delivery == 0) ? 1 : 0;
            //obj.UpdatedOnUtc = DateTime.Now;
            objWebsiteBanHangEntities.Entry(obj).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        ///XÁC NHẬN ĐƠN HÀNG
        //////--Field: Delivery có giá trị 1: Đơn hàng đã xác nhận nhưng chưa giao hàng, 2: Trạng thái đang giao hàng
        public ActionResult DeliveryToggle(int id)
        {
            var obj = objWebsiteBanHangEntities.Order_2119110245.Where(n => n.Id == id).FirstOrDefault();
            obj.Delivery = (obj.Delivery > 2) ? 1 : 2;
            //obj.UpdatedOnUtc = DateTime.Now;
            objWebsiteBanHangEntities.Entry(obj).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        ///XÁC NHẬN ĐƠN HÀNG
        //////--Field: Delivery có giá trị 3: Khách hàng chưa nhận hàng (Đang giao), 3: Đã nhận hàng (Đơn hàng kết thúc)
        public ActionResult DeliveryToggle_Recieve(int id)
        {
            var obj = objWebsiteBanHangEntities.Order_2119110245.Where(n => n.Id == id).FirstOrDefault();
            obj.Delivery = (obj.Delivery != 3) ? 3 : 2;
            //obj.UpdatedOnUtc = DateTime.Now;
            objWebsiteBanHangEntities.Entry(obj).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        //XEM CHI TIẾT ĐƠN HÀNG---------------------------------------------------------------------------------------

        public ActionResult Detail(int id)
        {
            if (Session["UserAdmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Home");
            }
            var listProductToOrder = new List<Product_2119110245>();
            var objProductToOrder = new Product_2119110245();
            var listOrder= objWebsiteBanHangEntities.Order_2119110245.Where(n => n.Id == id).ToList();
            var listOrderDetail = objWebsiteBanHangEntities.OrderDetail_2119110245.Where(n => n.OrderId == id).ToList();
            for (int i = 0; i < listOrderDetail.Count; i++)
            {
                var idproduct = listOrderDetail[i].ProductId;
                objProductToOrder = objWebsiteBanHangEntities.Product_2119110245.FirstOrDefault(a => a.Id == idproduct);
                listProductToOrder.Add(objProductToOrder);
                //listProductToOrder = objWebsiteBanHangEntities.Product_2119110245.ToList();
            }
            AdminOrderModel objOrderModel = new AdminOrderModel();
            objOrderModel.ListUser = objWebsiteBanHangEntities.User_2119110245.ToList();
            objOrderModel.ListProduct = listProductToOrder;
            objOrderModel.ListOrder = listOrder;
            objOrderModel.ListOrderDetail = listOrderDetail;
            return View(objOrderModel);

        }
    }
}