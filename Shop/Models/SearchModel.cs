using PagedList;
using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class SearchModel
    {
        public int Quantity { get; set; }
        public string key { get; set; }
        public IPagedList<Product_2119110245> listProduct{ get; set; }
    }
}