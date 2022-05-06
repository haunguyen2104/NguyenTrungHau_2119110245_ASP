using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class DashboardModel
    {
        public List<Product_2119110245> listProduct { get; set; }
        public List<User_2119110245> listUser { get; set; }
        public List<Order_2119110245> listOrder { get; set; }
        public float DeliverySuccessful { get; set; }
        public int OrderSuccess { get; set; }
        //public float TotalRevenue { get; set; }

    }
}