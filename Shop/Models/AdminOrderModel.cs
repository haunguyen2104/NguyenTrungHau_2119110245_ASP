using PagedList;
using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class AdminOrderModel
    {
        public List<Product_2119110245> ListProduct { get; set; }
        public List<User_2119110245> ListUser { get; set; }
        public List<Order_2119110245> ListOrder { get; set; }
        public List<OrderDetail_2119110245> ListOrderDetail { get; set; }
        public IPagedList<Order_2119110245> ILstOder { get; set; }
    }
}