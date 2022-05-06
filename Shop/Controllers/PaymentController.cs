using Shop.Context;
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
            double tongtien=0;
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //Lấy thông tin từ giỏ hàng từ biến session
                var lstCart = (List<CartModel>)Session["cart"];
                var listProduct = lstCart.ToList();
                for (int i = 0; i < listProduct.Count; i++)
                {
                   double pricePro = float.Parse(listProduct.FirstOrDefault().Product.Price.ToString());
                    double priceDisPro = float.Parse(listProduct.FirstOrDefault().Product.PriceDiscount.ToString());

                    if (priceDisPro<=0)
                    {
                        tongtien += listProduct.FirstOrDefault().Quantity * pricePro;
                    }
                    else
                    {
                        tongtien += listProduct.FirstOrDefault().Quantity * priceDisPro;
                    }
           
                }
                //Gán dữ liệu cho bảng Order
                Order_2119110245 objOrder = new Order_2119110245();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["Id"].ToString());
                objOrder.CreateOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objOrder.Delivery = 0;
                objOrder.Price = tongtien;
                objOrder.Address = Session["AddressUser"].ToString();
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
                    objDetail.Price = (item.Product.PriceDiscount == null) ? item.Product.Price : item.Product.PriceDiscount;
                    objDetail.TotalPrice = objDetail.Quantity * objDetail.Price ;
                    listOrderDetail.Add(objDetail);
                }
                objWebsiteBanHangEntities.OrderDetail_2119110245.AddRange(listOrderDetail);
                //Lưu thông tin
                objWebsiteBanHangEntities.SaveChanges();
                //Session;
                Session["cart"] = null;
            }
            return View();
        }
        
    }
}