using PagedList;
using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class SearchController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities= new WebsiteBanHangEntities();
        // GET: Search
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var listProduct = new List<Product_2119110245>();
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
                //lấy ds sản phẩm theo từ khoá tìm kiếm
                listProduct = objWebsiteBanHangEntities.Product_2119110245.Where(x => x.FullName.Contains(SearchString) && x.Deleted == false).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listProduct = objWebsiteBanHangEntities.Product_2119110245.Where(x => x.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listProduct = listProduct.OrderByDescending(x => x.Id).ToList();
            return View(listProduct.ToPagedList(pageNumber, pageSize));
        }
    }
}