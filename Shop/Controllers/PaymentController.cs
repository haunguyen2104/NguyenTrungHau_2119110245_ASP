﻿using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //Lấy thông tin từ giỏ hàng từ biến session
                var lstCart = (List<CartModel>)Session["cart"];
                //Gán dữ liệu cho bảng Order
                Order_2119110245 objOrder = new Order_2119110245();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["Id"].ToString());
                objOrder.CreateOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objWebsiteBanHangEntities.Order_2119110245.Add(objOrder);
                //Lưu thông tin
                objWebsiteBanHangEntities.SaveChanges();

                //Lấy OrderId vừa tạo mới để lưu vào bảng OrderDetail
                int intOrderId = objOrder.Id;
                List<OrderDetail_2119110245> listOrderDetail = new List<OrderDetail_2119110245>();
                foreach (var item in lstCart)
                {
                    OrderDetail_2119110245 objDetail = new OrderDetail_2119110245();
                    objDetail.Quantity = item.Quantity;
                    objDetail.OrderId = intOrderId;
                    objDetail.ProductId = item.Product.Id;
                    listOrderDetail.Add(objDetail);
                }
            objWebsiteBanHangEntities.OrderDetail_2119110245.AddRange(listOrderDetail);
            //Lưu thông tin
            objWebsiteBanHangEntities.SaveChanges();
                //Session;
           
            }
            return View();
        }
    }
}