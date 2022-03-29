using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class AdminHomeModel
    {
        public List<Product_2119110245> listProduct { get; set; }
        public List<Category_2119110245> listCategory { get; set; }
        public List<Brand_2119110245> listBrand { get; set; }
    }
}