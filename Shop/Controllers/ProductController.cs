using PagedList;
using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.Id == Id && n.Deleted == false).FirstOrDefault();
            return View(objProduct);
        }
        public ActionResult ProductCategoryList(int id)
        {
            //Lấy sản phẩm theo category
            var objProCate = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.CategoryId == id && n.Deleted == false).ToList();
            //Lấy danh mục 
            var objCate = objWebsiteBanHangEntities.Category_2119110245.Where(n => n.CategoryId == id).ToList();
            var lstBrand = objWebsiteBanHangEntities.Brand_2119110245.ToList();
            ProductCategoryModel objProductCategoryModel = new ProductCategoryModel();
            objProductCategoryModel.Id = id;
            objProductCategoryModel.listProduct = objProCate;
            objProductCategoryModel.listCategory = objCate;
            objProductCategoryModel.listBrand = lstBrand;

            return View(objProductCategoryModel);
        }
        public ActionResult ProductCategoryGrid(int id)
        {
            // Lấy sản phẩm theo category
            var objProCate = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.CategoryId == id && n.Deleted == false).ToList();
            //Lấy danh mục 
            var objCate = objWebsiteBanHangEntities.Category_2119110245.Where(n => n.CategoryId == id).ToList();
            var lstBrand = objWebsiteBanHangEntities.Brand_2119110245.ToList();

            ProductCategoryModel objProductCategoryModel = new ProductCategoryModel();
            objProductCategoryModel.Id = id;
            objProductCategoryModel.listProduct = objProCate;
            objProductCategoryModel.listCategory = objCate;
            objProductCategoryModel.listBrand = lstBrand;
            return View(objProductCategoryModel);
        }
        public ActionResult ProductBrandGrid(int id)
        {
            // Lấy sản phẩm theo thương hiệu
            var objProBrand = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.BrandId == id && n.Deleted == false).ToList();
            //Lấy thương hiệu 
            var objBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(n => n.BrandId == id).ToList();
            var objCate = objWebsiteBanHangEntities.Category_2119110245.ToList();
            ProductBrandModel objProductBrandModel = new ProductBrandModel();
            objProductBrandModel.Id = id;
            objProductBrandModel.listProduct = objProBrand;
            objProductBrandModel.listBrand = objBrand;
            objProductBrandModel.listCategory = objCate;

            return View(objProductBrandModel);
        }
        public ActionResult ProductBrandList(int id)
        {
            // Lấy sản phẩm theo category
            var lstProBrand = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.BrandId == id).ToList();
            //Lấy thương hiệu 
            var objBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(x => x.BrandId == id).ToList();

            var objCate = objWebsiteBanHangEntities.Category_2119110245.ToList();

            ProductBrandModel objProductBrandModel = new ProductBrandModel();
            objProductBrandModel.Id = id;
            objProductBrandModel.listProduct = lstProBrand;
            objProductBrandModel.listBrand = objBrand;
            objProductBrandModel.listCategory = objCate;
            return View(objProductBrandModel);
        }
        public ActionResult Offers(string currentFilter, string SearchString, int? page)
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
                listProduct = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.FullName.Contains(SearchString) && n.PriceDiscount != null && n.Deleted == false).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listProduct = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.PriceDiscount != null && n.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listProduct = listProduct.OrderBy(x => x.Id).ToList();
            return View(listProduct.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult SearchPage()
        {
            return View();
        }
    }
}